using System.Collections.Generic;

namespace Bery0za.Mazerator
{
	public class Cell
	{
        public static Cell Empty = new Cell(null);

        public IPosition Position { get; private set; }
		
		public HashSet<Cell> NeighbourCells { get; private set; }
		public HashSet<Cell> AdjacentCells { get; private set; }

        internal Cell(IPosition position)
		{
			NeighbourCells = new HashSet<Cell>();
			AdjacentCells = new HashSet<Cell>();

		    Position = position;
		}

        public override string ToString()
        {
            return "Cell " + Position.ToString();
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode();
        }
    }
}
