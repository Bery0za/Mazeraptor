using System;
using System.Collections.Generic;
using System.Linq;

namespace Bery0za.Mazerator.Solvers
{
    abstract public class MazeSolver
    {
        public delegate void SolvingStageHandler(ProgressStage stage, Maze maze, float percentage);

        public event SolvingStageHandler Stage;

        public List<Cell> SolvedPath { get; private set; }
        public Result Result { get; protected set; } = Result.NotSolvedYet;

        protected Maze maze;
        protected IStructure structure;
        protected bool cancel;

        float _percentage;

        public MazeSolver() { }

        public void SolveMaze(Maze maze, Cell startCell, Cell endCell)
        {
            Result = Result.NotSolvedYet;

            cancel = false;
            this.maze = maze;
            structure = maze.Structure;

            if (!structure.ContainsCells(startCell, endCell))
            {
                throw new ArgumentException("Maze doesn't contain one of the given cells");
            }

            Stage?.Invoke(ProgressStage.Started, maze, 0f);
            ProcessSolving(startCell, endCell);
        }

        public void Cancel()
        {
            cancel = true;
        }

        protected abstract void ProcessSolving(Cell startCell, Cell endCell);

        protected void TrackProgress(float percentage)
        {
            Stage?.Invoke(ProgressStage.Ongoing, maze, percentage);
        }

        protected virtual void SolutionFound(IEnumerable<Cell> solution)
        {
            SolvedPath = new List<Cell>(solution);
            Result = Result.SolutionFound;
            Stage?.Invoke(ProgressStage.Finished, maze, 100f);
        }

        protected virtual void SolutionNotFound()
        {
            Result = Result.SolutionNotFound;
            Stage?.Invoke(ProgressStage.Failed, maze, 0f);
        }

        protected List<Cell> ReconstructPath(Dictionary<Cell, Cell> cameFrom, Cell startCell, Cell endCell)
        {
            var foundPath = new List<Cell>();

            foundPath.Add(endCell);

            var addedCell = endCell;
            Cell prevCell;

            while (addedCell != startCell)
            {
                prevCell = cameFrom[addedCell];
                foundPath.Add(prevCell);
                addedCell = prevCell;
            }

            return foundPath;
        }
    }
}