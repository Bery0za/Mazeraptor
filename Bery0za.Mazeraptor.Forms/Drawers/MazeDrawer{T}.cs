using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Bery0za.Mazerator.Forms.Drawers
{
    public abstract class MazeDrawer<T> : IMazeDrawer<T>
        where T : IStructure
    {
        public Bitmap DrawMaze(T structure, DrawingParameters parameters)
        {
            return DrawMazeOrdered(structure, parameters, structure);
        }

        public Bitmap DrawMazeOrdered(T structure, DrawingParameters parameters, IEnumerable<Cell> order)
        {
            if (!parameters.strokeEnabled && !parameters.fillEnabled) return null;

            var size = CalculateBitmapSize(structure, parameters);
            Bitmap bitmap = new Bitmap(size.width, size.height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                if (parameters.fillEnabled)
                {
                    FillMaze(graphics, structure, parameters, order);
                }

                if (parameters.strokeEnabled)
                {
                    StrokeMaze(graphics, structure, parameters);
                }
            }

            return bitmap;
        }
        
        protected abstract void FillMaze(Graphics graphics, T structure, DrawingParameters parameters, IEnumerable<Cell> order);
        protected abstract void StrokeMaze(Graphics graphics, T structure, DrawingParameters parameters);
        protected abstract (int width, int height) CalculateBitmapSize(T structure, DrawingParameters parameters);
    }
}