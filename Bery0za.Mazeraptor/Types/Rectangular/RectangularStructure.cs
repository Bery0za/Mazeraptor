using System.Collections.Generic;

namespace Bery0za.Mazerator.Types.Rectangular
{
    public class RectangularStructure : Structure<RectangularParameters, RectangularPosition>
    {
        private Cell[,] cells;

        public RectangularStructure(RectangularParameters parameters)
            : base(parameters) { }

        public override void Init()
        {
            cells = new Cell[parameters.width, parameters.height];

            for (int i = 0; i < parameters.width; i++)
            {
                for (int j = 0; j < parameters.height; j++)
                {
                    cells[i, j] = CreateCellAtPosition(new RectangularPosition(i, j));
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
            return cells[position.x, position.y];
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

            foreach (var neighbour in RectangularStructure.neighbors)
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
            for (int i = 0; i < parameters.width; i++)
            {
                for (int j = 0; j < parameters.height; j++)
                {
                    yield return cells[i, j];
                }
            }
        }
    }
}