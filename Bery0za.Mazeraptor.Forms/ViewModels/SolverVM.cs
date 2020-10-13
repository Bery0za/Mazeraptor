using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Solvers;
using Bery0za.Mazerator.Types;

namespace Bery0za.Mazerator.Forms.ViewModels
{
    public enum SolverType
    {
        AStar,
        BreadthFirst,
        DepthFirstRecursive,
        DepthFirstStacked
    }

    public class SolverVM : ViewModel
    {
        public PropertyWrapper<Maze> Maze = new PropertyWrapper<Maze>(Mazerator.Maze.Empty);
        public PropertyWrapper<bool> SolvingEnabled = new PropertyWrapper<bool>(false);
        public PropertyWrapper<IEnumerable<Cell>> Cells = new PropertyWrapper<IEnumerable<Cell>>(Enumerable.Empty<Cell>()); 
        public PropertyWrapper<Cell> SourceCell = new PropertyWrapper<Cell>(Cell.Empty);
        public PropertyWrapper<Cell> TargetCell = new PropertyWrapper<Cell>(Cell.Empty);
        public PropertyWrapper<SolverType> Type = new PropertyWrapper<SolverType>(SolverType.AStar); 
        public PropertyWrapper<IEnumerable<SolverType>> AvailableTypes = new PropertyWrapper<IEnumerable<SolverType>>();
        public PropertyWrapper<ProgressVM> Progress = new PropertyWrapper<ProgressVM>(ProgressVM.Empty);

        public PropertyWrapper<Result> SolveResult = new PropertyWrapper<Result>(Result.NotSolvedYet);
        public PropertyWrapper<List<Cell>> SolvedPath = new PropertyWrapper<List<Cell>>(new List<Cell>());

        public SolverVM()
        {
            AvailableTypes.Value = new [] { SolverType.AStar, SolverType.BreadthFirst, SolverType.DepthFirstRecursive, SolverType.DepthFirstStacked };
            Maze.ValueChanged += OnMazeChange;
        }

        private void OnMazeChange(Maze current, Maze previous)
        {
            if (current != Mazerator.Maze.Empty && current.Structure.Any())
            {
                SolvingEnabled.Set(true);
                Cells.Set(current.Structure);
                SourceCell.Set(current.Structure.ElementAt(0));
                TargetCell.Set(current.Structure.ElementAt(0));
            }
            else
            {
                SolvingEnabled.Set(false);
                Cells.Set(Enumerable.Empty<Cell>());
                SourceCell.Set(Cell.Empty);
                TargetCell.Set(Cell.Empty);
            }

            SolveResult.Set(Result.NotSolvedYet);
            SolvedPath.Set(new List<Cell>());
        }

        public void Solve()
        {
            if (Maze.Value != Mazerator.Maze.Empty
                && Maze.Value.Structure.ContainsCells(SourceCell.Value, TargetCell.Value))
            {
                Progress.Set(new ProgressVM(DoWork, RunWorkerCompleted));
                Progress.Value.Run();
            }
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            bool failed = false;

            MazeSolver solver = CreateSolver();

            solver.Stage += SolverOnStage;
            solver.SolveMaze(Maze.Value, SourceCell.Value, TargetCell.Value);
            solver.Stage -= SolverOnStage;

            if (!failed) e.Result = solver;

            void SolverOnStage(ProgressStage stage, Maze maze, float percentage)
            {
                if (worker.CancellationPending && (stage == ProgressStage.Started || stage == ProgressStage.Ongoing))
                {
                    e.Cancel = true;
                    solver.Cancel();
                }

                switch (stage)
                {
                    case ProgressStage.Failed:
                        failed = true;
                        break;
                    case ProgressStage.Ongoing:
                        worker.ReportProgress((int)percentage);
                        break;
                }
            }
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Result is MazeSolver solver)
            {
                SolveResult.Set(solver.Result);
                SolvedPath.Set(solver.SolvedPath);
            }
            else
            {
                SolveResult.Set(Result.NotSolvedYet);
                SolvedPath.Set(new List<Cell>());
            }
        }

        private MazeSolver CreateSolver()
        {
            switch (Type.Value)
            {
                case SolverType.AStar:
                    return new AStarSolver();
                case SolverType.BreadthFirst:
                    return new BreadthFirstSolver();
                case SolverType.DepthFirstRecursive:
                    return new DepthFirstSolverRecursive();
                case SolverType.DepthFirstStacked:
                    return new DepthFirstSolverStack();
                default:
                    throw new ArgumentException();
            }
        }

        public override void Destroy()
        {
            Maze.ValueChanged -= OnMazeChange;
        }
    }
}
