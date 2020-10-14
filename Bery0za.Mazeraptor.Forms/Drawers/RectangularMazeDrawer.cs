using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

using Bery0za.Mazerator.Types.Rectangular;

namespace Bery0za.Mazerator.Forms.Drawers
{
    public class RectangularMazeDrawer : MazeDrawer<RectangularStructure>
    {
        protected override void FillMaze(Graphics graphics,
                                         RectangularStructure structure,
                                         DrawingParameters parameters,
                                         IEnumerable<Cell> order)
        {
            graphics.TranslateTransform(parameters.strokeWidth, parameters.strokeWidth);

            float drawWidth = parameters.cellSize;
            float drawHeight = parameters.cellSize;

            int i = 0;
            int count = order.Count();
            Brush brush = new SolidBrush(parameters.fillColor);

            foreach (Cell cell in order)
            {
                if (parameters.fillType == FillType.GenerationGradient)
                {
                    brush = new SolidBrush(Helpers.Lerp(Color.Black, parameters.fillColor, (float)i / count));
                }

                RectangularPosition pos = cell.Position as RectangularPosition;
                int x = pos.x;
                int y = pos.y;

                PointF p1 = new PointF(x * drawWidth, y * drawHeight);
                PointF p2 = new PointF((x + 1) * drawWidth, y * drawHeight);
                PointF p3 = new PointF((x + 1) * drawWidth, (y + 1) * drawHeight);
                PointF p4 = new PointF(x * drawWidth, (y + 1) * drawHeight);

                GraphicsPath bounds = new GraphicsPath();
                bounds.AddLine(p1, p2);
                bounds.AddLine(p2, p3);
                bounds.AddLine(p3, p4);
                bounds.AddLine(p4, p1);

                graphics.FillPath(brush, bounds);

                i++;
            }

            graphics.ResetTransform();
        }

        protected override void StrokeMaze(Graphics graphics,
                                           RectangularStructure structure,
                                           DrawingParameters parameters)
        {
            graphics.TranslateTransform(parameters.strokeWidth, parameters.strokeWidth);

            float width = structure.parameters.width;
            float height = structure.parameters.height;
            float drawWidth = parameters.cellSize;
            float drawHeight = parameters.cellSize;

            Pen pen = new Pen(parameters.strokeColor, parameters.strokeWidth);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    PointF p1 = new PointF(x * drawWidth, y * drawHeight);
                    PointF p2 = new PointF((x + 1) * drawWidth, y * drawHeight);
                    PointF p3 = new PointF((x + 1) * drawWidth, (y + 1) * drawHeight);
                    PointF p4 = new PointF(x * drawWidth, (y + 1) * drawHeight);

                    Cell curCell = structure.GetCellAtPosition(new RectangularPosition(x, y));

                    if (!structure.ContainsCellAtPosition(new RectangularPosition(x - 1, y)))
                    {
                        graphics.DrawLine(pen, p1, p4);
                    }

                    if (!structure.ContainsCellAtPosition(new RectangularPosition(x, y - 1)))
                    {
                        graphics.DrawLine(pen, p1, p2);
                    }

                    if (!structure.ContainsCellAtPosition(new RectangularPosition(x + 1, y))
                        || !structure.IsAdjacent(curCell,
                                                 structure.GetCellAtPosition(new RectangularPosition(x + 1, y))))
                    {
                        graphics.DrawLine(pen, p2, p3);
                    }

                    if (!structure.ContainsCellAtPosition(new RectangularPosition(x, y + 1))
                        || !structure.IsAdjacent(curCell,
                                                 structure.GetCellAtPosition(new RectangularPosition(x, y + 1))))
                    {
                        graphics.DrawLine(pen, p3, p4);
                    }
                }
            }

            graphics.ResetTransform();
        }

        protected override (int width, int height) CalculateBitmapSize(RectangularStructure structure,
                                                                       DrawingParameters parameters)
        {
            int width = (int)(structure.parameters.width * parameters.cellSize + parameters.strokeWidth * 2);
            int height = (int)(structure.parameters.height * parameters.cellSize + parameters.strokeWidth * 2);

            return (width, height);
        }
    }
}