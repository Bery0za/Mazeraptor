using System;
using System.Collections.Generic;
using System.Linq;

namespace Bery0za.Mazerator.Solvers
{
    public class DepthFirstSolverRecursive : MazeSolver
    {
        private HashSet<Cell> plottedCells;
        private List<Cell> foundPath;

        public DepthFirstSolverRecursive()
            : base() { }

        override protected void ProcessSolving(Cell startCell, Cell endCell)
        {
            foundPath = new List<Cell>();

            if (DFS(startCell, endCell))
            {
                SolutionFound(foundPath);
            }
            else
            {
                SolutionNotFound();
            }
        }

        private bool DFS(Cell curCell, Cell endCell)
        {
            float procTotalCount = structure.Count() * 0.01f;

            plottedCells = new HashSet<Cell>();
            plottedCells.Add(curCell);

            TrackProgress(plottedCells.Count / procTotalCount);
            if (cancel) return false;

            if (curCell == endCell)
            {
                foundPath.Add(curCell);
                return true;
            }

            IEnumerable<Cell> nextCells = curCell.AdjacentCells.Except(plottedCells);

            if (nextCells.Any())
            {
                foreach (Cell nextCell in nextCells)
                {
                    if (DFS(nextCell, endCell))
                    {
                        foundPath.Add(curCell);
                        return true;
                    }
                }
            }

            return false;
        }
    }
}