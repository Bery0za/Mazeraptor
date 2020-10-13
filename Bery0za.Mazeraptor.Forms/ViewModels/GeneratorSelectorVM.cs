using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Generators;

namespace Bery0za.Mazerator.Forms.ViewModels
{
    public interface IGeneratorVM
    {
        MazeGenerator CreateGenerator();
    }

    public enum CellSelector
    {
        Random,
        Oldest,
        Newest,
        Middle,
        OldestRandom,
        NewestRandom,
        OldestNewest
    }

    public enum NeighborSelector
    {
        Random
    }

    public enum GeneratorType
    {
        RecursiveBacktracker,
        GrowingTree
    }

    public class GeneratorSelectorVM : ViewModel
    {
        private static Dictionary<CellSelector, MazeGenerator.CellSelector> _cellSelectors = new Dictionary<CellSelector, MazeGenerator.CellSelector>()
        {
            { CellSelector.Random, MazeGenerator.RandomCellSelector },
            { CellSelector.Oldest, MazeGenerator.OldestCellSelector },
            { CellSelector.Newest, MazeGenerator.NewestCellSelector },
            { CellSelector.Middle, MazeGenerator.MiddleCellSelector },
        };

        private static Dictionary<CellSelector, Func<float, MazeGenerator.CellSelector>> _parametrizedSelectors = new Dictionary<CellSelector, Func<float, MazeGenerator.CellSelector>>()
        {
            { CellSelector.OldestRandom, MazeGenerator.OldestRandomCellSelector },
            { CellSelector.NewestRandom, MazeGenerator.NewestRandomCellSelector },
            { CellSelector.OldestNewest, MazeGenerator.OldestNewestCellSelector },
        };

        private static Dictionary<NeighborSelector, MazeGenerator.NeighborSelector> _neighborSelectors = new Dictionary<NeighborSelector, MazeGenerator.NeighborSelector>()
        {
            {NeighborSelector.Random, MazeGenerator.RandomNeighbourSelector},
        };

        public readonly ContextWrapper<IGeneratorVM> Generator = new ContextWrapper<IGeneratorVM>(new RecursiveBacktrackerGeneratorVM());
        public readonly PropertyWrapper<GeneratorType> Type = new PropertyWrapper<GeneratorType>(GeneratorType.RecursiveBacktracker);
        public readonly PropertyWrapper<IEnumerable<GeneratorType>> AvailableTypes = new PropertyWrapper<IEnumerable<GeneratorType>>();

        public GeneratorSelectorVM()
        {
            AvailableTypes.Value = new[] { GeneratorType.RecursiveBacktracker, GeneratorType.GrowingTree };
            Type.ValueChanged += OnGeneratorTypeChange;
        }

        public MazeGenerator CreateGenerator()
        {
            return Generator.Value.CreateGenerator();
        }

        public override IEnumerable<IContext> DefineChildren()
        {
            return new List<IContext>() { Generator };
        }

        private void OnGeneratorTypeChange(GeneratorType current, GeneratorType previous)
        {
            switch (current)
            {
                case GeneratorType.RecursiveBacktracker:
                    Generator.Set(new RecursiveBacktrackerGeneratorVM());
                    break;
                case GeneratorType.GrowingTree:
                    Generator.Set(new GrowingTreeGeneratorVM());
                    break;
            }
        }

        public override void Destroy()
        {
            Type.ValueChanged -= OnGeneratorTypeChange;
        }

        internal static bool IsSelectorParametrized(CellSelector type)
        {
            if (_parametrizedSelectors.ContainsKey(type)) return true;
            if (_cellSelectors.ContainsKey(type)) return false;

            throw new ArgumentException();
        }

        internal static MazeGenerator.CellSelector CreateCellSelector(CellSelector type, float parameter = 1)
        {
            switch (type)
            {
                case CellSelector.Random:
                case CellSelector.Oldest:
                case CellSelector.Newest:
                case CellSelector.Middle:
                    return _cellSelectors[type];
                case CellSelector.OldestRandom:
                case CellSelector.NewestRandom:
                case CellSelector.OldestNewest:
                    return _parametrizedSelectors[type](parameter);
                default:
                    throw new ArgumentException();
            }
        }
        internal static MazeGenerator.NeighborSelector CreateNeighborSelector(NeighborSelector type, float parameter = 1)
        {
            switch (type)
            {
                case NeighborSelector.Random:
                    return _neighborSelectors[type];
                default:
                    throw new ArgumentException();
            }
        }
    }
}
