using System.Collections.Generic;

namespace Bery0za.Mazerator.Types.Rectangular
{
	public class RectangularStructure : Structure<RectangularParameters, RectangularPosition>
	{
		public override int Count => _cells.Length;

		Cell[,] _cells;

		public RectangularStructure(RectangularParameters parameters)
			: base(parameters)
		{
			
		}

		public override void Init()
		{
			_cells = new Cell[parameters.width, parameters.height];

			for (var i = 0; i < parameters.width; i++)
			{
				for (var j = 0; j < parameters.height; j++)
				{
					_cells[i, j] = CreateCellAtPosition(new RectangularPosition(i, j));
				}
			}

			base.Init();
		}

		protected override bool ContainsAtPosition(RectangularPosition position)
		{
			return position.x > -1
			       && position.x < parameters.width
			       && position.y > -1
			       && position.y < parameters.height;
		}

		protected override Cell CellAtPosition(RectangularPosition position)
		{
			return _cells[position.x, position.y];
		}

		static RectangularPosition[] neighbors = new RectangularPosition[]
		{
			new RectangularPosition(1, 0),
			new RectangularPosition(0, -1),
			new RectangularPosition(-1, 0),
			new RectangularPosition(0, 1)
		};

		protected override IEnumerable<Cell> GetNeighborsAtPosition(RectangularPosition position)
		{
			foreach (var neighbour in neighbors)
			{
				var nPos = position + neighbour;

				if (ContainsAtPosition(nPos)) yield return CellAtPosition(nPos);
			}
		}

		public override IEnumerator<Cell> GetEnumerator()
		{
			for (var i = 0; i < parameters.width; i++)
			{
				for (var j = 0; j < parameters.height; j++)
				{
					yield return _cells[i, j];
				}
			}
		}
	}
}