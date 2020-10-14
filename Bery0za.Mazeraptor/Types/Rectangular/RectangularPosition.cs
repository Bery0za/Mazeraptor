using System;

using Bery0za.Methematica.Utils;

namespace Bery0za.Mazerator.Types.Rectangular
{
    public class RectangularPosition : Position<RectangularPosition>
    {
        public readonly int x;
        public readonly int y;

        public RectangularPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override int GetHashCode()
        {
            return (int)Cantor.Pairing(x, y);
        }

        public override string ToString()
        {
            return "{X = " + x + ", Y = " + y + "}";
        }

        protected override float DistanceTo(RectangularPosition pos)
        {
            return Math.Abs(this.x - pos.x) + Math.Abs(this.y - pos.y);
        }

        public static RectangularPosition operator +(RectangularPosition a, RectangularPosition b)
        {
            return new RectangularPosition(a.x + b.x, a.y + b.y);
        }

        public static RectangularPosition operator -(RectangularPosition a, RectangularPosition b)
        {
            return new RectangularPosition(a.x - b.x, a.y - b.y);
        }
    }
}