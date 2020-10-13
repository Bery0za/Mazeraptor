using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bery0za.Mazerator.Types
{
    public abstract class Position<T> : IPosition where T : IPosition
    {
        public float DistanceTo(IPosition position)
        {
            if (position is T typedPosition)
            {
                return DistanceTo(typedPosition);
            }

            throw new InvalidCastException("Can't measure distance to position of another type");
        }

        protected abstract float DistanceTo(T position);
    }
}
