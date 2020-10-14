using System;

namespace Bery0za.Mazerator.Types.Triangular
{
    public class TriangularParameters : Parameters
    {
        public readonly uint side;

        public TriangularParameters(uint side)
        {
            this.side = side;

            CheckParameters();
        }

        protected override void CheckParameters()
        {
            if (side < 1)
            {
                throw new ArgumentException("Incorrect parameters for maze");
            }
        }
    }
}