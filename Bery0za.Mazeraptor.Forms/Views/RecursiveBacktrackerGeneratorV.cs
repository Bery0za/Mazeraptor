using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Forms.ViewModels;

namespace Bery0za.Mazerator.Forms.Views
{
    public partial class RecursiveBacktrackerGeneratorV : UserControl, IBindable<RecursiveBacktrackerGeneratorVM>,
                                                          IGeneratorV
    {
        public PropertyWrapper<CellSelector> FirstCellSelector = new PropertyWrapper<CellSelector>();
        public PropertyWrapper<CellSelector> LeftCellSelector = new PropertyWrapper<CellSelector>();
        public PropertyWrapper<NeighborSelector> NeighborSelector = new PropertyWrapper<NeighborSelector>();

        public PropertyWrapper<IEnumerable<CellSelector>> AvailableCellSelectors =
            new PropertyWrapper<IEnumerable<CellSelector>>();

        public PropertyWrapper<IEnumerable<NeighborSelector>> AvailableNeighborSelectors =
            new PropertyWrapper<IEnumerable<NeighborSelector>>();

        public RecursiveBacktrackerGeneratorV()
        {
            InitializeComponent();
        }

        public void OnContextAttach(RecursiveBacktrackerGeneratorVM context,
                                    IList<IBinding> bindings,
                                    IBinder<RecursiveBacktrackerGeneratorVM> binder)
        {
            bindings.Add(Binder.Side(FirstCellSelector).To(context.FirstCellSelector).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(LeftCellSelector).To(context.LeftCellSelector).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(NeighborSelector).To(context.NeighborSelector).Using(BindingFlow.TwoWay));

            bindings.Add(Binder.Side(AvailableCellSelectors)
                               .To(context.AvailableCellSelectors)
                               .Using(BindingFlow.OneWay));

            bindings.Add(Binder.Side(AvailableNeighborSelectors)
                               .To(context.AvailableNeighborSelectors)
                               .Using(BindingFlow.OneWay));

            AvailableCellSelectors.ValueChanged += OnAvailableCellSelectorsChange;
            AvailableNeighborSelectors.ValueChanged += OnAvailableNeighborSelectorChange;

            firstCellList.SelectedValueChanged += FirstCellListOnSelectedValueChanged;
            leftCellList.SelectedValueChanged += LeftCellListOnSelectedValueChanged;
            neighborCellList.SelectedValueChanged += NeighborCellListOnSelectedValueChanged;
        }

        private void OnAvailableCellSelectorsChange(IEnumerable<CellSelector> current,
                                                    IEnumerable<CellSelector> previous)
        {
            firstCellList.DataSource = current.ToArray();
            leftCellList.DataSource = current.ToArray();
        }

        private void OnAvailableNeighborSelectorChange(IEnumerable<NeighborSelector> current,
                                                       IEnumerable<NeighborSelector> previous)
        {
            neighborCellList.DataSource = current.ToArray();
        }

        private void FirstCellListOnSelectedValueChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(firstCellList.SelectedValue.ToString(), true, out CellSelector type))
            {
                FirstCellSelector.Set(type);
            }
            else
            {
                FirstCellSelector.Set(CellSelector.Random);
            }
        }

        private void LeftCellListOnSelectedValueChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(leftCellList.SelectedValue.ToString(), true, out CellSelector type))
            {
                LeftCellSelector.Set(type);
            }
            else
            {
                LeftCellSelector.Set(CellSelector.Random);
            }
        }

        private void NeighborCellListOnSelectedValueChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(neighborCellList.SelectedValue.ToString(), true, out NeighborSelector type))
            {
                NeighborSelector.Set(type);
            }
            else
            {
                NeighborSelector.Set(ViewModels.NeighborSelector.Random);
            }
        }

        public void OnContextDestroy()
        {
            AvailableCellSelectors.ValueChanged -= OnAvailableCellSelectorsChange;
            AvailableNeighborSelectors.ValueChanged -= OnAvailableNeighborSelectorChange;

            firstCellList.SelectedValueChanged -= FirstCellListOnSelectedValueChanged;
            leftCellList.SelectedValueChanged -= LeftCellListOnSelectedValueChanged;
            neighborCellList.SelectedValueChanged -= NeighborCellListOnSelectedValueChanged;
        }
    }
}