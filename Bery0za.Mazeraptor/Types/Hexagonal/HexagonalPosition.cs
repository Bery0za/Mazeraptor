using System;

using Bery0za.Methematica.Utils;

namespace Bery0za.Mazerator.Types.Hexagonal
{
    public class HexagonalPosition : Position<HexagonalPosition>
    {
        public readonly int q;
        public readonly int r;

        public int s
        {
            get
            {
                return -q - r;
            }
        }

        public HexagonalPosition(int q, int r)
        {
            this.q = q;
            this.r = r;
        }

        public override int GetHashCode()
        {
            return (int)Cantor.Pairing(q, r);
        }

        public override string ToString()
        {
            return "{Q = " + q + ", R = " + r + ", S = " + s + "}";
        }

        protected override float DistanceTo(HexagonalPosition pos)
        {
            return (Math.Abs(q - pos.q) + Math.Abs(r - pos.r) + Math.Abs(s - pos.s)) * 0.5f;
        }

        public static HexagonalPosition operator +(HexagonalPosition a, HexagonalPosition b)
        {
            return new HexagonalPosition(a.q + b.q, a.r + b.r);
        }

        public static HexagonalPosition operator -(HexagonalPosition a, HexagonalPosition b)
        {
            return new HexagonalPosition(a.q - b.q, a.r - b.r);
        }
    }
}