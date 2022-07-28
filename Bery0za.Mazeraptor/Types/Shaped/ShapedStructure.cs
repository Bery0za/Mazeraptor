using System.Collections.Generic;

using Bery0za.Mazerator.Types.Rectangular;
using Bery0za.Methematica.Utils;

namespace Bery0za.Mazerator.Types.Shaped
{
	public class ShapedStructure : Structure<ShapedParameters, RectangularPosition>
	{
		public override int Count => _cells.Count;

		Dictionary<ulong, Cell> _cells;

		public ShapedStructure(ShapedParameters parameters)
			: base(parameters)
		{
			
		}

		public override void Init()
		{
			_cells = new Dictionary<ulong, Cell>();

			for (var i = 0; i < parameters.shape.Width; i++)
			{
				for (var j = 0; j < parameters.shape.Height; j++)
				{
					var pos = new RectangularPosition(i, j);

					if (parameters.shape.ContainsAtPosition(pos))
					{
						_cells.Add(Cantor.Pairing(i, j), CreateCellAtPosition(pos));
					}
				}
			}

			base.Init();
		}

		protected override bool ContainsAtPosition(RectangularPosition position)
		{
			if (position.x < 0
			    || position.y < 0
			    || position.x >= parameters.shape.Width
			    || position.y >= parameters.shape.Height) return false;

			return parameters.shape.ContainsAtPosition(position);
		}

		protected override Cell CellAtPosition(RectangularPosition position)
		{
			return _cells[Cantor.Pairing(position.x, position.y)];
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
			return _cells.Values.GetEnumerator();
		}
	}
}