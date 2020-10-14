using System;

namespace Bery0za.Mazerator.Types.Rectangular
{
    public class RectangularParameters : Parameters
    {
        public readonly int width;
        public readonly int height;

        public RectangularParameters(int width, int height)
        {
            this.width = width;
            this.height = height;

            CheckParameters();
        }

        protected override void CheckParameters()
        {
            if (width < 1 || height < 1)
            {
                throw new ArgumentException("Incorrect parameters for maze");
            }
        }
    }
}