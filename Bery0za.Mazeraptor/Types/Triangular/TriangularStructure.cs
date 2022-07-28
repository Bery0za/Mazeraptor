using System.Collections.Generic;
using System.Linq;

using Bery0za.Methematica.Utils;

namespace Bery0za.Mazerator.Types.Triangular
{
	public class TriangularStructure : Structure<TriangularParameters, TriangularPosition>
	{
		public override int Count => _cells.Count;

		Dictionary<ulong, Cell> _cells;

		public TriangularStructure(TriangularParameters parameters)
			: base(parameters)
		{
			
		}

		public override void Init()
		{
			_cells = new Dictionary<ulong, Cell>();
			var side = (int)parameters.side;

			for (var q = 0; q < side; q++)
			{
				var r2 = side - q;

				for (var r = 0; r < r2; r++)
				{
					var s1 = -q - r;
					_cells.Add(Cantor.Tuple(q, r, s1), CreateCellAtPosition(new TriangularPosition(q, r, s1)));

					if ((q + r) < side - 1)
					{
						var s2 = s1 - 1;
						_cells.Add(Cantor.Tuple(q, r, s2), CreateCellAtPosition(new TriangularPosition(q, r, s2)));
					}
				}
			}

			base.Init();
		}

		protected override bool ContainsAtPosition(TriangularPosition position)
		{
			return _cells.ContainsKey(Cantor.Tuple(position.q, position.r, position.s));
		}

		protected override Cell CellAtPosition(TriangularPosition position)
		{
			return _cells[Cantor.Tuple(position.q, position.r, position.s)];
		}

		static TriangularPosition[] neighbors = new TriangularPosition[]
		{
			new TriangularPosition(1, 0, 0),
			new TriangularPosition(0, 1, 0),
			new TriangularPosition(0, 0, 1),
		};

		protected override IEnumerable<Cell> GetNeighborsAtPosition(TriangularPosition position)
		{
			foreach (var neighbour in neighbors)
			{
				var nPos = position.Pointed() ? position - neighbour : position + neighbour;

				if (ContainsAtPosition(nPos)) yield return CellAtPosition(nPos);
			}
		}

		public override IEnumerator<Cell> GetEnumerator()
		{
			return _cells.Select(pair => pair.Value).GetEnumerator();
		}
	}
}