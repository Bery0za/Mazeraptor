using System;
using System.Collections.Generic;
using System.Linq;

namespace Bery0za.Mazerator.Generators
{
    public abstract class MazeGenerator
    {
        public delegate Cell CellSelector(IEnumerable<Cell> cells, Random random);

        public delegate Cell NeighborSelector(Cell cell, Random random);

        public delegate void GenerationStageHandler(ProgressStage stage, IStructure structure, float percentage);

        public delegate void VisitedCellHandler(IStructure structure, Cell cell);

        public event GenerationStageHandler Stage;
        public event VisitedCellHandler CellVisited;

        public List<Cell> GenerationPath { get; private set; }

        protected IStructure structure;
        protected bool cancel;

        bool _trackGenerationPath;
        float _percentage;

        public MazeGenerator(bool trackGenerationPath = false)
        {
            _trackGenerationPath = trackGenerationPath;
        }

        internal void GenerateMaze(IStructure structure, Random random)
        {
            cancel = false;
            this.structure = structure;
            if (_trackGenerationPath) GenerationPath = new List<Cell>(structure.Count());
            Stage?.Invoke(ProgressStage.Started, this.structure, 0);

            if (ProcessGenerating(random))
            {
                GenerationSuccessfull();
            }
            else
            {
                GenerationFailed();
            }
        }

        public void Cancel()
        {
            cancel = true;
        }

        protected abstract bool ProcessGenerating(Random random);

        protected void TrackProgress(float percentage)
        {
            Stage?.Invoke(ProgressStage.Ongoing, structure, percentage);
        }

        protected virtual void VisitCell(Cell cell)
        {
            CellVisited?.Invoke(structure, cell);
            if (_trackGenerationPath) GenerationPath.Add(cell);
        }

        protected void GenerationSuccessfull()
        {
            Stage?.Invoke(ProgressStage.Finished, structure, 100f);
        }

        protected void GenerationFailed()
        {
            Stage?.Invoke(ProgressStage.Failed, structure, 0f);
        }

        public static Cell RandomCellSelector(IEnumerable<Cell> cells, Random random)
        {
            return cells.ElementAt(random.Next(cells.Count()));
        }

        public static Cell OldestCellSelector(IEnumerable<Cell> cells, Random random)
        {
            return cells.First();
        }

        public static Cell NewestCellSelector(IEnumerable<Cell> cells, Random random)
        {
            return cells.Last();
        }

        public static Cell MiddleCellSelector(IEnumerable<Cell> cells, Random random)
        {
            return cells.ElementAt(cells.Count() / 2);
        }

        public static CellSelector NewestRandomCellSelector(float ratio)
        {
            if (ratio < 0 || ratio > 1) throw new ArgumentOutOfRangeException("Ratio must be in range [0; 1].");

            return (cells, random) => random.NextDouble() < ratio
                ? NewestCellSelector(cells, random)
                : RandomCellSelector(cells, random);
        }

        public static CellSelector OldestRandomCellSelector(float ratio)
        {
            if (ratio < 0 || ratio > 1) throw new ArgumentOutOfRangeException("Ratio must be in range [0; 1].");

            return (cells, random) => random.NextDouble() < ratio
                ? OldestCellSelector(cells, random)
                : RandomCellSelector(cells, random);
        }

        public static CellSelector OldestNewestCellSelector(float ratio)
        {
            if (ratio < 0 || ratio > 1) throw new ArgumentOutOfRangeException("Ratio must be in range [0; 1].");

            return (cells, random) => random.NextDouble() < ratio
                ? OldestCellSelector(cells, random)
                : NewestCellSelector(cells, random);
        }

        public static CellSelector OrderedCellSelector(Func<Cell, float> valueSelector)
        {
            return (cells, random) => cells.OrderBy(valueSelector).First();
        }

        public static Cell RandomNeighbourSelector(Cell cell, Random random)
        {
            var notAdjacentCells = cell.NeighbourCells.Except(cell.AdjacentCells);
            return notAdjacentCells.ElementAt(random.Next(notAdjacentCells.Count()));
        }
    }
}