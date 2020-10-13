using System;

namespace Bery0za.Mazerator.Types.Hexagonal
{    
    public class HexagonalParameters : Parameters
    {
        public readonly uint rings;

        public HexagonalParameters(uint rings)
        {
            this.rings = rings;

            CheckParameters();
        }

        protected override void CheckParameters()
        {
            if (rings < 1)
            {
                throw new ArgumentException("Incorrect parameters for maze");
            }
        }
    }
}
