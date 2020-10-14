using System;
using System.Collections.Generic;
using System.Linq;

namespace Bery0za.Mazerator.Solvers
{
    public class DepthFirstSolverStack : MazeSolver
    {
        private HashSet<Cell> plottedCells;
        private Stack<Cell> openSet;

        public DepthFirstSolverStack()
            : base() { }

        protected override void ProcessSolving(Cell startCell, Cell endCell)
        {
            if (DFS(startCell, endCell))
            {
                SolutionFound(openSet);
            }
            else
            {
                SolutionNotFound();
            }
        }

        private bool DFS(Cell startCell, Cell endCell)
        {
            float procTotalCount = structure.Count() * 0.01f;

            plottedCells = new HashSet<Cell>();
            openSet = new Stack<Cell>();

            openSet.Push(startCell);

            while (openSet.Any())
            {
                var curCell = openSet.Peek();
                plottedCells.Add(curCell);

                if (curCell == endCell)
                {
                    return true;
                }

                Cell nextCell;

                if ((nextCell = curCell.AdjacentCells.Except(plottedCells).FirstOrDefault()) != null)
                {
                    openSet.Push(nextCell);
                }
                else
                {
                    openSet.Pop();
                }

                TrackProgress(plottedCells.Count / procTotalCount);
                if (cancel) return false;
            }

            return false;
        }
    }
}