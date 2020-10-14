using System;
using System.Collections.Generic;
using System.Linq;

namespace Bery0za.Mazerator.Generators
{
    public class GrowingTreeGenerator : MazeGenerator
    {
        private readonly CellSelector firstSelector;
        private readonly CellSelector carvingCellSelector;
        private readonly CellSelector leftCellSelector;
        private readonly NeighborSelector neighborSelector;

        private List<Cell> carvingCells;
        private HashSet<Cell> notVisitedCells;
        private HashSet<Cell> visitedCells;

        public GrowingTreeGenerator(CellSelector firstSelector = null,
                                    CellSelector carvingCellSelector = null,
                                    CellSelector leftCellSelector = null,
                                    NeighborSelector neighborSelector = null,
                                    bool trackGenerationPath = false)
            : base(trackGenerationPath)
        {
            this.firstSelector = firstSelector ?? RandomCellSelector;
            this.carvingCellSelector = carvingCellSelector ?? RandomCellSelector;
            this.leftCellSelector = leftCellSelector ?? RandomCellSelector;
            this.neighborSelector = neighborSelector ?? RandomNeighbourSelector;
        }

        protected override bool ProcessGenerating(Random random)
        {
            float procTotalCount = structure.Count() * 0.01f;

            carvingCells = new List<Cell>();
            notVisitedCells = new HashSet<Cell>(structure);
            visitedCells = new HashSet<Cell>();

            carvingCells.Add(firstSelector(structure, random));

            while (carvingCells.Any())
            {
                TrackProgress(visitedCells.Count / procTotalCount);
                if (cancel) return false;

                Cell curCell = carvingCellSelector(carvingCells, random);
                VisitCell(curCell);

                if (curCell.NeighbourCells.Except(visitedCells).Any())
                {
                    Cell neighborCell;

                    do
                    {
                        neighborCell = neighborSelector(curCell, random);
                    }
                    while (visitedCells.Contains(neighborCell));

                    VisitCell(neighborCell);
                    structure.SetAdjacent(curCell, neighborCell);
                    carvingCells.Add(neighborCell);
                }
                else
                {
                    carvingCells.Remove(curCell);
                }

                // We do need this if our structure has discontinuities
                if (!carvingCells.Any() && notVisitedCells.Any())
                {
                    carvingCells.Add(leftCellSelector(notVisitedCells, random));
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