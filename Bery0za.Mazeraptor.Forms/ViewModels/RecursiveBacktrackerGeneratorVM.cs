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
    public class RecursiveBacktrackerGeneratorVM : ViewModel, IGeneratorVM
    {
        public PropertyWrapper<CellSelector> FirstCellSelector = new PropertyWrapper<CellSelector>(CellSelector.Random);
        public PropertyWrapper<CellSelector> LeftCellSelector = new PropertyWrapper<CellSelector>(CellSelector.Random);

        public PropertyWrapper<NeighborSelector> NeighborSelector =
            new PropertyWrapper<NeighborSelector>(ViewModels.NeighborSelector.Random);

        public PropertyWrapper<IEnumerable<CellSelector>> AvailableCellSelectors =
            new PropertyWrapper<IEnumerable<CellSelector>>();

        public PropertyWrapper<IEnumerable<NeighborSelector>> AvailableNeighborSelectors =
            new PropertyWrapper<IEnumerable<NeighborSelector>>();

        public RecursiveBacktrackerGeneratorVM()
        {
            AvailableCellSelectors.Value = new[] { CellSelector.Random };
            AvailableNeighborSelectors.Value = new[] { ViewModels.NeighborSelector.Random };
        }

        public MazeGenerator CreateGenerator()
        {
            return new RecursiveBacktrackerGenerator(GeneratorSelectorVM.CreateCellSelector(FirstCellSelector.Value),
                                                     GeneratorSelectorVM.CreateCellSelector(LeftCellSelector.Value),
                                                     GeneratorSelectorVM.CreateNeighborSelector(NeighborSelector.Value),
                                                     true);
        }
    }
}