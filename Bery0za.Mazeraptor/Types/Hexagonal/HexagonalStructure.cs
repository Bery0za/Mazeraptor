using System;
using System.Collections.Generic;
using System.Linq;

using Bery0za.Methematica.Utils;

namespace Bery0za.Mazerator.Types.Hexagonal
{
	public class HexagonalStructure : Structure<HexagonalParameters, HexagonalPosition>
	{
		public override int Count => _cells.Count;

		Dictionary<ulong, Cell> _cells;

		public HexagonalStructure(HexagonalParameters parameters)
			: base(parameters)
		{
			
		}

		public override void Init()
		{
			_cells = new Dictionary<ulong, Cell>();
			var rings = parameters.rings;

			for (var q = (int)(-rings); q <= rings; q++)
			{
				var r1 = (int)Math.Max(-rings, -q - rings);
				var r2 = (int)Math.Min(rings, -q + rings);

				for (var r = r1; r <= r2; r++)
				{
					_cells.Add(Cantor.Pairing(q, r), CreateCellAtPosition(new HexagonalPosition(q, r)));
				}
			}

			base.Init();
		}

		protected override bool ContainsAtPosition(HexagonalPosition position)
		{
			return _cells.ContainsKey(Cantor.Pairing(position.q, position.r));
		}

		protected override Cell CellAtPosition(HexagonalPosition position)
		{
			return _cells[Cantor.Pairing(position.q, position.r)];
		}

		static HexagonalPosition[] neighbors = new HexagonalPosition[]
		{
			new HexagonalPosition(1, -1),
			new HexagonalPosition(1, 0),
			new HexagonalPosition(0, 1),
			new HexagonalPosition(-1, 1),
			new HexagonalPosition(-1, 0),
			new HexagonalPosition(0, -1)
		};

		protected override IEnumerable<Cell> GetNeighborsAtPosition(HexagonalPosition position)
		{
			foreach (var neighbour in neighbors)
			{
				var nPos = neighbour + position;

				if (ContainsAtPosition(nPos)) yield return CellAtPosition(nPos);
			}
		}

		public override IEnumerator<Cell> GetEnumerator()
		{
			return _cells.Select(pair => pair.Value).GetEnumerator();
		}
	}
}