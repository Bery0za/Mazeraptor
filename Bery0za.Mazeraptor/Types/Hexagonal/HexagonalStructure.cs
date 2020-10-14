using System;
using System.Collections.Generic;

using Bery0za.Methematica.Utils;

namespace Bery0za.Mazerator.Types.Hexagonal
{
    public class HexagonalStructure : Structure<HexagonalParameters, HexagonalPosition>
    {
        private Dictionary<ulong, Cell> cells;

        public HexagonalStructure(HexagonalParameters parameters)
            : base(parameters) { }

        public override void Init()
        {
            cells = new Dictionary<ulong, Cell>();
            uint rings = parameters.rings;

            for (int q = (int)(-rings); q <= rings; q++)
            {
                int r1 = (int)Math.Max(-rings, -q - rings);
                int r2 = (int)Math.Min(rings, -q + rings);

                for (int r = r1; r <= r2; r++)
                {
                    cells.Add(Cantor.Pairing(q, r), CreateCellAtPosition(new HexagonalPosition(q, r)));
                }
            }

            base.Init();
        }

        protected override bool ContainsAtPosition(HexagonalPosition position)
        {
            return cells.ContainsKey(Cantor.Pairing(position.q, position.r));
        }

        protected override Cell CellAtPosition(HexagonalPosition position)
        {
            return cells[Cantor.Pairing(position.q, position.r)];
        }

        private static HexagonalPosition[] neighbors = new HexagonalPosition[]
        {
            new HexagonalPosition(1, -1),
            new HexagonalPosition(1, 0),
            new HexagonalPosition(0, 1),
            new HexagonalPosition(-1, 1),
            new HexagonalPosition(-1, 0),
            new HexagonalPosition(0, -1)
        };

        protected override HashSet<Cell> GetNeighborsAtPosition(HexagonalPosition position)
        {
            HashSet<Cell> neighbors = new HashSet<Cell>();

            foreach (HexagonalPosition neighbour in HexagonalStructure.neighbors)
            {
                HexagonalPosition nPos = neighbour + position;

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