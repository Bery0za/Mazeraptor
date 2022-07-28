using System;
using System.Collections.Generic;
using System.Linq;

namespace Bery0za.Mazerator.Solvers
{
    public class BreadthFirstSolver : MazeSolver
    {
        Dictionary<Cell, Cell> cameFrom = new Dictionary<Cell, Cell>();
        Queue<Cell> openSet;

        public BreadthFirstSolver()
            : base() { }

        override protected void ProcessSolving(Cell startCell, Cell endCell)
        {
            if (BFS(startCell, endCell))
            {
                SolutionFound(ReconstructPath(cameFrom, startCell, endCell));
            }
            else
            {
                SolutionNotFound();
            }
        }

        bool BFS(Cell startCell, Cell endCell)
        {
            var procTotalCount = structure.Count() * 0.01f;

            openSet = new Queue<Cell>();
            openSet.Enqueue(startCell);

            IEnumerable<Cell> neighborSet;

            do
            {
                var curCell = openSet.Dequeue();
                neighborSet = curCell.AdjacentCells.Except(cameFrom.Values);

                foreach (var nextCell in neighborSet)
                {
                    cameFrom.Add(nextCell, curCell);
                    openSet.Enqueue(nextCell);
                }

                TrackProgress(cameFrom.Count / procTotalCount);
                if (cancel) return false;
            }
            while (!neighborSet.Contains(endCell) && openSet.Any());

            if (!cameFrom.Keys.Contains(endCell))
            {
                return false;
            }

            return true;
        }
    }
}