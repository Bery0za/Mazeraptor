using System;
using System.Collections.Generic;

using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Generators;

namespace Bery0za.Mazerator.Forms.ViewModels
{
    public class GrowingTreeGeneratorVM : ViewModel, IGeneratorVM
    {
        public PropertyWrapper<CellSelector> FirstCellSelector = new PropertyWrapper<CellSelector>(CellSelector.Random);
        public PropertyWrapper<float> FirstCellParameter = new PropertyWrapper<float>(0.5f);
        public PropertyWrapper<bool> FirstCellParameterAvailable = new PropertyWrapper<bool>(false);

        public PropertyWrapper<CellSelector> CarvingCellSelector =
            new PropertyWrapper<CellSelector>(CellSelector.Random);

        public PropertyWrapper<float> CarvingCellParameter = new PropertyWrapper<float>(0.5f);
        public PropertyWrapper<bool> CarvingCellParameterAvailable = new PropertyWrapper<bool>(false);
        public PropertyWrapper<CellSelector> LeftCellSelector = new PropertyWrapper<CellSelector>(CellSelector.Random);
        public PropertyWrapper<float> LeftCellParameter = new PropertyWrapper<float>(0.5f);
        public PropertyWrapper<bool> LeftCellParameterAvailable = new PropertyWrapper<bool>(false);

        public PropertyWrapper<NeighborSelector> NeighborSelector =
            new PropertyWrapper<NeighborSelector>(ViewModels.NeighborSelector.Random);

        public PropertyWrapper<IEnumerable<CellSelector>> AvailableCellSelectors =
            new PropertyWrapper<IEnumerable<CellSelector>>();

        public PropertyWrapper<IEnumerable<NeighborSelector>> AvailableNeighborSelectors =
            new PropertyWrapper<IEnumerable<NeighborSelector>>();

        private PropertyChanged<CellSelector> _firstCellParameterAvailable;
        private PropertyChanged<CellSelector> _carvingCellParameterAvailable;
        private PropertyChanged<CellSelector> _leftCellParameterAvailable;

        public GrowingTreeGeneratorVM()
        {
            AvailableCellSelectors.Value = new[]
            {
                CellSelector.Random, CellSelector.Oldest, CellSelector.Newest, CellSelector.Middle,
                CellSelector.OldestRandom, CellSelector.NewestRandom, CellSelector.OldestNewest
            };

            AvailableNeighborSelectors.Value = new[] { ViewModels.NeighborSelector.Random };

            _firstCellParameterAvailable = ParameterAvailable(FirstCellParameterAvailable);
            _carvingCellParameterAvailable = ParameterAvailable(CarvingCellParameterAvailable);
            _leftCellParameterAvailable = ParameterAvailable(LeftCellParameterAvailable);

            FirstCellSelector.ValueChanged += _firstCellParameterAvailable;
            CarvingCellSelector.ValueChanged += _carvingCellParameterAvailable;
            LeftCellSelector.ValueChanged += _leftCellParameterAvailable;
        }

        public PropertyChanged<CellSelector> ParameterAvailable(PropertyWrapper<bool> parameter)
        {
            return (value, previous) => parameter.Set(GeneratorSelectorVM.IsSelectorParametrized(value));
        }

        public MazeGenerator CreateGenerator()
        {
            return new GrowingTreeGenerator(GeneratorSelectorVM.CreateCellSelector(FirstCellSelector.Value,
                                                                                   FirstCellParameter.Value),
                                            GeneratorSelectorVM.CreateCellSelector(CarvingCellSelector.Value,
                                                                                   CarvingCellParameter.Value),
                                            GeneratorSelectorVM.CreateCellSelector(LeftCellSelector.Value,
                                                                                   LeftCellParameter.Value),
                                            GeneratorSelectorVM.CreateNeighborSelector(NeighborSelector.Value),
                                            true);
        }

        public override void Destroy()
        {
            FirstCellSelector.ValueChanged -= _firstCellParameterAvailable;
            CarvingCellSelector.ValueChanged -= _carvingCellParameterAvailable;
            LeftCellSelector.ValueChanged -= _leftCellParameterAvailable;
        }
    }
}