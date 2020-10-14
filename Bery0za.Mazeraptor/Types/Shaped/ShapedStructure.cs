using System.Collections.Generic;

using Bery0za.Mazerator.Types.Rectangular;
using Bery0za.Methematica.Utils;

namespace Bery0za.Mazerator.Types.Shaped
{
    public class ShapedStructure : Structure<ShapedParameters, RectangularPosition>
    {
        private Dictionary<ulong, Cell> cells;

        public ShapedStructure(ShapedParameters parameters)
            : base(parameters) { }

        public override void Init()
        {
            cells = new Dictionary<ulong, Cell>();

            for (int i = 0; i < parameters.shape.Width; i++)
            {
                for (int j = 0; j < parameters.shape.Height; j++)
                {
                    RectangularPosition pos = new RectangularPosition(i, j);

                    if (parameters.shape.ContainsAtPosition(pos))
                    {
                        cells.Add(Cantor.Pairing(i, j), CreateCellAtPosition(pos));
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
            return cells[Cantor.Pairing(position.x, position.y)];
        }

        private static RectangularPosition[] neighbors = new RectangularPosition[]
        {
            new RectangularPosition(1, 0),
            new RectangularPosition(0, -1),
            new RectangularPosition(-1, 0),
            new RectangularPosition(0, 1)
        };

        protected override HashSet<Cell> GetNeighborsAtPosition(RectangularPosition position)
        {
            HashSet<Cell> neighbors = new HashSet<Cell>();

            foreach (var neighbour in ShapedStructure.neighbors)
            {
                RectangularPosition nPos = position + neighbour;

                if (ContainsAtPosition(nPos))
                {
                    neighbors.Add(CellAtPosition(nPos));
                }
            }

            return neighbors;
        }

        public override IEnumerator<Cell> GetEnumerator()
        {
            return cells.Values.GetEnumerator();
        }
    }
}