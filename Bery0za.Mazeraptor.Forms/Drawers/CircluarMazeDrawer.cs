using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

using Bery0za.Mazerator.Types.Circular;

namespace Bery0za.Mazerator.Forms.Drawers
{
    public class CircularMazeDrawer : MazeDrawer<CircularStructure>
    {
        protected override void FillMaze(Graphics graphics,
                                         CircularStructure structure,
                                         DrawingParameters parameters,
                                         IEnumerable<Cell> order)
        {
            float translate = parameters.strokeWidth
                              + structure.parameters.rings * parameters.cellSize
                              + parameters.cellSize * 0.5f;

            graphics.TranslateTransform(translate, translate);

            float ringHeight = parameters.cellSize;
            float halfHeight = ringHeight * 0.5f;
            int prevRingCount = 1;

            int i = 0;
            int count = order.Count();
            Brush brush = new SolidBrush(parameters.fillColor);

            foreach (Cell cell in order)
            {
                if (parameters.fillType == FillType.GenerationGradient)
                {
                    brush = new SolidBrush(Helpers.Lerp(Color.Black, parameters.fillColor, (float)i / count));
                }

                CircularPosition pos = cell.Position as CircularPosition;
                int x = pos.ring;
                int y = pos.step;

                if (x == 0)
                {
                    graphics.FillEllipse(brush, -halfHeight, -halfHeight, ringHeight, ringHeight);

                    continue;
                }

                int cellsInRing = CircularFunctions.CellsInRing(x, structure.parameters.ratio);

                var polarSideA = CircularFunctions.CircularPositionToPolar(x, y, ringHeight, cellsInRing);
                var polarSideB = CircularFunctions.CircularPositionToPolar(x, y + 1, ringHeight, cellsInRing);

                float innerSize = (x * ringHeight - halfHeight);
                float outerSize = (x * ringHeight + halfHeight);

                var t1 = CircularFunctions.PolarToCartesian(innerSize, polarSideA.angle);
                var t2 = CircularFunctions.PolarToCartesian(outerSize, polarSideA.angle);
                var t3 = CircularFunctions.PolarToCartesian(outerSize, polarSideB.angle);
                var t4 = CircularFunctions.PolarToCartesian(innerSize, polarSideB.angle);

                RectangleF inner = new RectangleF(-innerSize, -innerSize, innerSize * 2, innerSize * 2);
                RectangleF outer = new RectangleF(-outerSize, -outerSize, outerSize * 2, outerSize * 2);

                float sweep = CircularFunctions.RadToDeg(polarSideB.angle)
                              - CircularFunctions.RadToDeg(polarSideA.angle);

                GraphicsPath bounds = new GraphicsPath();
                bounds.AddLine(t1.Item1, t1.Item2, t2.Item1, t2.Item2);
                bounds.AddArc(outer, CircularFunctions.RadToDeg(polarSideA.angle), sweep);
                bounds.AddLine(t3.Item1, t3.Item2, t4.Item1, t4.Item2);
                bounds.AddArc(inner, CircularFunctions.RadToDeg(polarSideB.angle), -sweep);
                bounds.CloseFigure();

                graphics.FillPath(brush, bounds);

                i++;
            }

            graphics.ResetTransform();
        }

        protected override void StrokeMaze(Graphics graphics, CircularStructure structure, DrawingParameters parameters)
        {
            float translate = parameters.strokeWidth
                              + structure.parameters.rings * parameters.cellSize
                              + parameters.cellSize * 0.5f;

            graphics.TranslateTransform(translate, translate);

            float ringHeight = parameters.cellSize;
            float halfHeight = ringHeight * 0.5f;
            int prevRingCount = 1;

            Pen pen = new Pen(parameters.strokeColor, parameters.strokeWidth);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;

            for (int x = 1; x <= structure.parameters.rings; x++)
            {
                int cellsNumber = CircularFunctions.CellsInRing(x, structure.parameters.ratio, prevRingCount);

                for (int y = 0; y < cellsNumber; y++)
                {
                    Brush brush = new SolidBrush(parameters.fillColor);

                    var polarSideA = CircularFunctions.CircularPositionToPolar(x, y, ringHeight, cellsNumber);
                    var polarSideB = CircularFunctions.CircularPositionToPolar(x, y + 1, ringHeight, cellsNumber);

                    float innerSize = (x * ringHeight - halfHeight);
                    float outerSize = (x * ringHeight + halfHeight);

                    var t1 = CircularFunctions.PolarToCartesian(innerSize, polarSideA.angle);
                    var t2 = CircularFunctions.PolarToCartesian(outerSize, polarSideA.angle);
                    var t3 = CircularFunctions.PolarToCartesian(outerSize, polarSideB.angle);
                    var t4 = CircularFunctions.PolarToCartesian(innerSize, polarSideB.angle);

                    RectangleF inner = new RectangleF(-innerSize, -innerSize, innerSize * 2, innerSize * 2);
                    RectangleF outer = new RectangleF(-outerSize, -outerSize, outerSize * 2, outerSize * 2);

                    float sweep = CircularFunctions.RadToDeg(polarSideB.angle)
                                  - CircularFunctions.RadToDeg(polarSideA.angle);

                    Cell curCell = structure.GetCellAtPosition(new CircularPosition(x, y));

                    foreach (Cell neighbourCell in curCell.NeighbourCells)
                    {
                        CircularPosition neighborPosition = neighbourCell.Position as CircularPosition;

                        if (neighborPosition.ring == (x - 1) && !structure.IsAdjacent(curCell, neighbourCell))
                        {
                            graphics.DrawArc(pen, inner, CircularFunctions.RadToDeg(polarSideB.angle), -sweep);
                        }

                        if ((neighborPosition.step == (y + 1) || y == (cellsNumber - 1) && neighborPosition.step == 0)
                            && !structure.IsAdjacent(curCell, neighbourCell))
                        {
                            graphics.DrawLine(pen, t3.x, t3.y, t4.x, t4.y);
                        }
                    }

                    if (x == structure.parameters.rings)
                    {
                        graphics.DrawArc(pen, outer, CircularFunctions.RadToDeg(polarSideA.angle), sweep);
                    }
                }

                prevRingCount = cellsNumber;
            }

            graphics.ResetTransform();
        }

        protected override (int width, int height) CalculateBitmapSize(CircularStructure structure,
                                                                       DrawingParameters parameters)
        {
            int diameter =
                (int)((structure.parameters.rings * 2 + 1) * parameters.cellSize + 2 * parameters.strokeWidth);

            return (diameter, diameter);
        }
    }
}