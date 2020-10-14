using System.Collections.Generic;

using Bery0za.Methematica.Utils;

namespace Bery0za.Mazerator.Types.Triangular
{
    public class TriangularStructure : Structure<TriangularParameters, TriangularPosition>
    {
        private Dictionary<ulong, Cell> cells;

        public TriangularStructure(TriangularParameters parameters)
            : base(parameters) { }

        public override void Init()
        {
            cells = new Dictionary<ulong, Cell>();
            int side = (int)parameters.side;

            for (int q = 0; q < side; q++)
            {
                int r2 = side - q;

                for (int r = 0; r < r2; r++)
                {
                    int s1 = -q - r;
                    cells.Add(Cantor.Tuple(q, r, s1), CreateCellAtPosition(new TriangularPosition(q, r, s1)));

                    if ((q + r) < side - 1)
                    {
                        int s2 = s1 - 1;
                        cells.Add(Cantor.Tuple(q, r, s2), CreateCellAtPosition(new TriangularPosition(q, r, s2)));
                    }
                }
            }

            base.Init();
        }

        protected override bool ContainsAtPosition(TriangularPosition position)
        {
            return cells.ContainsKey(Cantor.Tuple(position.q, position.r, position.s));
        }

        protected override Cell CellAtPosition(TriangularPosition position)
        {
            return cells[Cantor.Tuple(position.q, position.r, position.s)];
        }

        private static TriangularPosition[] neighbors = new TriangularPosition[]
        {
            new TriangularPosition(1, 0, 0),
            new TriangularPosition(0, 1, 0),
            new TriangularPosition(0, 0, 1),
        };

        protected override HashSet<Cell> GetNeighborsAtPosition(TriangularPosition position)
        {
            HashSet<Cell> neighbors = new HashSet<Cell>();

            foreach (TriangularPosition neighbour in TriangularStructure.neighbors)
            {
                TriangularPosition nPos = position.Pointed() ? position - neighbour : position + neighbour;

                if (ContainsAtPosition(nPos))
                {
                    neighbors.Add(CellAtPosition(nPos));
                }
            }

            return neighbors;
        }

        public override IEnumerator<Cell> GetEnumerator()
        {
            foreach (var pair in cells)
            {
                yield return pair.Value;
            }
        }
    }
}