using System;

using Bery0za.Methematica.Utils;

namespace Bery0za.Mazerator.Types.Triangular
{
    public class TriangularPosition : Position<TriangularPosition>
    {
        public readonly int q;
        public readonly int r;
        public readonly int s;

        public TriangularPosition(int q, int r, int s)
        {
            this.q = q;
            this.r = r;
            this.s = s;
        }

        public override int GetHashCode()
        {
            return (int)Cantor.Tuple(q, r, s);
        }

        public override string ToString()
        {
            return "{Q = " + q + ", R = " + r + ", S = " + s + "}";
        }

        public bool Pointed()
        {
            return q + r + s == 0;
        }

        protected override float DistanceTo(TriangularPosition pos)
        {
            return Math.Abs(this.q - pos.q) + Math.Abs(this.r - pos.r) + Math.Abs(this.s - pos.s);
        }

        public static TriangularPosition operator +(TriangularPosition a, TriangularPosition b)
        {
            return new TriangularPosition(a.q + b.q, a.r + b.r, a.s + b.s);
        }

        public static TriangularPosition operator -(TriangularPosition a, TriangularPosition b)
        {
            return new TriangularPosition(a.q - b.q, a.r - b.r, a.s - b.s);
        }
    }
}