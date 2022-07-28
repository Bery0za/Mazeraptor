using System.Collections.Generic;
using System.Linq;

namespace Bery0za.Mazerator.Types.Circular
{
	public class CircularStructure : Structure<CircularParameters, CircularPosition>
	{
		public override int Count => _cells.Count;

		List<HashSet<Cell>> _cells;

		HashSet<Cell> this[int ring] => _cells.ElementAt(ring);

		Cell this[int ring, int step]
		{
			get
			{
				var cellsNumber = CellsNumberInRing(ring);
				var angle = step % cellsNumber;

				while (angle < 0)
				{
					angle += cellsNumber;
				}

				while (angle >= CellsNumberInRing(ring))
				{
					angle -= cellsNumber;
				}

				return _cells.ElementAt(ring).ElementAt(angle);
			}
		}

		public CircularStructure(CircularParameters parameters)
			: base(parameters)
		{
			
		}

		public override void Init()
		{
			_cells = new List<HashSet<Cell>>();
			var prevRingCount = 0;

			for (var i = 0; i <= parameters.rings; i++)
			{
				_cells.Add(new HashSet<Cell>());
				var cellsNumber = CircularFunctions.CellsInRing(i, parameters.ratio, prevRingCount);

				for (var j = 0; j < cellsNumber; j++)
				{
					_cells.ElementAt(i).Add(CreateCellAtPosition(new CircularPosition(i, j)));
				}

				prevRingCount = cellsNumber;
			}

			base.Init();
		}

		protected override bool ContainsAtPosition(CircularPosition position)
		{
			return position.ring <= parameters.rings;
		}

		protected override Cell CellAtPosition(CircularPosition position)
		{
			return this[position.ring, position.step];
		}

		protected override IEnumerable<Cell> GetNeighborsAtPosition(CircularPosition position)
		{
			var ring = position.ring;
			var step = position.step;

			if (ring == 0)
			{
				foreach (var c in this[1]) yield return c;

				yield break;
			}

			yield return this[ring, step - 1];
			yield return this[ring, step + 1];

			if (ring == parameters.rings) yield break;

			if (CellsNumberInRing(ring) < CellsNumberInRing(ring + 1))
			{
				yield return this[ring + 1, step * 2];
				yield return this[ring + 1, step * 2 + 1];
			}
			else
			{
				yield return this[ring + 1, step];
			}
		}

		public override IEnumerator<Cell> GetEnumerator()
		{
			return _cells.SelectMany(ring => ring).GetEnumerator();
		}

		public int CellsNumberInRing(int ring)
		{
			return _cells.ElementAt(ring).Count;
		}
	}
}