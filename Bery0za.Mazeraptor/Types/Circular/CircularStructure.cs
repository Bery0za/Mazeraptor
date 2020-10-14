using System;
using System.Collections.Generic;
using System.Linq;

namespace Bery0za.Mazerator.Types.Circular
{
    public class CircularStructure : Structure<CircularParameters, CircularPosition>
    {
        private List<HashSet<Cell>> cells;

        private HashSet<Cell> this[int ring]
        {
            get
            {
                return cells.ElementAt(ring);
            }
        }

        private Cell this[int ring, int step]
        {
            get
            {
                int cellsNumber = CellsNumberInRing(ring);
                int angle = step % cellsNumber;

                while (angle < 0)
                {
                    angle += cellsNumber;
                }

                while (angle >= CellsNumberInRing(ring))
                {
                    angle -= cellsNumber;
                }

                return cells.ElementAt(ring).ElementAt(angle);
            }
        }

        public CircularStructure(CircularParameters parameters)
            : base(parameters) { }

        public override void Init()
        {
            cells = new List<HashSet<Cell>>();
            int prevRingCount = 0;

            for (int i = 0; i <= parameters.rings; i++)
            {
                cells.Add(new HashSet<Cell>());
                int cellsNumber = CircularFunctions.CellsInRing(i, parameters.ratio, prevRingCount);

                for (int j = 0; j < cellsNumber; j++)
                {
                    cells.ElementAt(i).Add(CreateCellAtPosition(new CircularPosition(i, j)));
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

        protected override HashSet<Cell> GetNeighborsAtPosition(CircularPosition position)
        {
            int ring = position.ring;
            int step = position.step;

            HashSet<Cell> neighbors = new HashSet<Cell>();

            if (ring == 0)
            {
                foreach (Cell c in this[1])
                {
                    neighbors.Add(c);
                }

                return neighbors;
            }

            neighbors.Add(this[ring, step - 1]);
            neighbors.Add(this[ring, step + 1]);

            if (ring == parameters.rings)
            {
                return neighbors;
            }

            if (CellsNumberInRing(ring) < CellsNumberInRing(ring + 1))
            {
                neighbors.Add(this[ring + 1, step * 2]);
                neighbors.Add(this[ring + 1, step * 2 + 1]);
            }
            else
            {
                neighbors.Add(this[ring + 1, step]);
            }

            return neighbors;
        }

        public override IEnumerator<Cell> GetEnumerator()
        {
            foreach (HashSet<Cell> ring in cells)
            {
                foreach (Cell cell in ring)
                {
                    yield return cell;
                }
            }
        }

        public int CellsNumberInRing(int ring)
        {
            return cells.ElementAt(ring).Count();
        }
    }
}