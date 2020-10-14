﻿using System;

using Bery0za.Methematica.Utils;

namespace Bery0za.Mazerator.Types.Circular
{
    public class CircularPosition : Position<CircularPosition>
    {
        public readonly int ring;
        public readonly int step;

        public CircularPosition(int ring, int step)
        {
            this.ring = ring;
            this.step = step;
        }

        public override int GetHashCode()
        {
            return (int)Cantor.Pairing(ring, step);
        }

        public override string ToString()
        {
            return "{Ring = " + ring + ", Step = " + step + "}";
        }

        protected override float DistanceTo(CircularPosition pos)
        {
            return Math.Abs(pos.ring - this.ring) + Math.Abs(pos.step - this.step);
        }
    }
}