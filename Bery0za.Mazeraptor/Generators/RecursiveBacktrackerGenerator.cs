using System;
using System.Collections.Generic;
using System.Linq;

namespace Bery0za.Mazerator.Generators
{
    public class RecursiveBacktrackerGenerator : MazeGenerator
    {
        readonly CellSelector firstCellSelector;
        readonly CellSelector leftCellSelector;
        readonly NeighborSelector neighborSelector;

        Stack<Cell> carvingCells;
        HashSet<Cell> notVisitedCells;
        HashSet<Cell> visitedCells;
        Cell curCell;

        public RecursiveBacktrackerGenerator(CellSelector firstCellSelector = null,
                                             CellSelector leftCellSelector = null,
                                             NeighborSelector neighborSelector = null,
                                             bool trackGenerationPath = false)
            : base(trackGenerationPath)
        {
            this.firstCellSelector = firstCellSelector ?? RandomCellSelector;
            this.leftCellSelector = leftCellSelector ?? RandomCellSelector;
            this.neighborSelector = neighborSelector ?? RandomNeighbourSelector;
        }

        protected override bool ProcessGenerating(Random random)
        {
            var procTotalCount = (float)structure.Count() / 100;

            carvingCells = new Stack<Cell>();
            notVisitedCells = new HashSet<Cell>(structure);
            visitedCells = new HashSet<Cell>();

            curCell = firstCellSelector(structure, random);
            VisitCell(curCell);

            while (notVisitedCells.Any())
            {
                TrackProgress(visitedCells.Count / procTotalCount);
                if (cancel) return false;

                if (notVisitedCells.Intersect(curCell.NeighbourCells).Any())
                {
                    Cell rndCell;
                    carvingCells.Push(curCell);

                    do
                    {
                        rndCell = neighborSelector(curCell, random);
                    }
                    while (visitedCells.Contains(rndCell));

                    structure.SetAdjacent(curCell, rndCell);

                    curCell = rndCell;
                    VisitCell(curCell);
                }
                else if (carvingCells.Any())
                {
                    curCell = carvingCells.Pop();
                }
                else
                {
                    curCell = leftCellSelector(notVisitedCells, random);
                    VisitCell(curCell);
                }
            }

            return true;
        }

        protected override void VisitCell(Cell cell)
        {
            visitedCells.Add(cell);
            notVisitedCells.Remove(cell);
            base.VisitCell(cell);
        }
    }
}