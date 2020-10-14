using System;

namespace Bery0za.Mazerator.Types.Circular
{
    public class CircularParameters : Parameters
    {
        public readonly int rings;
        public readonly float ratio;

        public CircularParameters(int rings, float ratio)
        {
            this.rings = rings;
            this.ratio = ratio;

            CheckParameters();
        }

        protected override void CheckParameters()
        {
            if (rings < 1 || ratio < 0)
            {
                throw new ArgumentException("Incorrect parameters for maze");
            }
        }
    }
}