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
    public partial class GrowingTreeGeneratorV : UserControl, IBindable<GrowingTreeGeneratorVM>, IGeneratorV
    {
        public PropertyWrapper<CellSelector> FirstCellSelector = new PropertyWrapper<CellSelector>();
        public PropertyWrapper<float> FirstCellParameter = new PropertyWrapper<float>();
        public PropertyWrapper<bool> FirstCellParameterAvailable = new PropertyWrapper<bool>();
        public PropertyWrapper<CellSelector> CarvingCellSelector = new PropertyWrapper<CellSelector>();
        public PropertyWrapper<float> CarvingCellParameter = new PropertyWrapper<float>();
        public PropertyWrapper<bool> CarvingCellParameterAvailable = new PropertyWrapper<bool>();
        public PropertyWrapper<CellSelector> LeftCellSelector = new PropertyWrapper<CellSelector>();
        public PropertyWrapper<float> LeftCellParameter = new PropertyWrapper<float>();
        public PropertyWrapper<bool> LeftCellParameterAvailable = new PropertyWrapper<bool>();
        public PropertyWrapper<NeighborSelector> NeighborSelector = new PropertyWrapper<NeighborSelector>();

        public PropertyWrapper<IEnumerable<CellSelector>> AvailableCellSelectors =
            new PropertyWrapper<IEnumerable<CellSelector>>();

        public PropertyWrapper<IEnumerable<NeighborSelector>> AvailableNeighborSelectors =
            new PropertyWrapper<IEnumerable<NeighborSelector>>();

        private PropertyChanged<bool> _firstNumericEnabled;
        private PropertyChanged<bool> _carvingNumericEnabled;
        private PropertyChanged<bool> _leftNumericEnabled;

        public GrowingTreeGeneratorV()
        {
            InitializeComponent();
        }

        public void OnContextAttach(GrowingTreeGeneratorVM context,
                                    IList<IBinding> bindings,
                                    IBinder<GrowingTreeGeneratorVM> binder)
        {
            bindings.Add(Binder.Side(FirstCellSelector).To(context.FirstCellSelector).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(FirstCellParameter).To(context.FirstCellParameter).Using(BindingFlow.TwoWay));

            bindings.Add(Binder.Side(FirstCellParameterAvailable)
                               .To(context.FirstCellParameterAvailable)
                               .Using(BindingFlow.TwoWay));

            bindings.Add(Binder.Side(CarvingCellSelector).To(context.CarvingCellSelector).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(CarvingCellParameter).To(context.CarvingCellParameter).Using(BindingFlow.TwoWay));

            bindings.Add(Binder.Side(CarvingCellParameterAvailable)
                               .To(context.CarvingCellParameterAvailable)
                               .Using(BindingFlow.TwoWay));

            bindings.Add(Binder.Side(LeftCellSelector).To(context.LeftCellSelector).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(LeftCellParameter).To(context.LeftCellParameter).Using(BindingFlow.TwoWay));

            bindings.Add(Binder.Side(LeftCellParameterAvailable)
                               .To(context.LeftCellParameterAvailable)
                               .Using(BindingFlow.TwoWay));

            bindings.Add(Binder.Side(NeighborSelector).To(context.NeighborSelector).Using(BindingFlow.TwoWay));

            bindings.Add(Binder.Side(AvailableCellSelectors)
                               .To(context.AvailableCellSelectors)
                               .Using(BindingFlow.OneWay));

            bindings.Add(Binder.Side(AvailableNeighborSelectors)
                               .To(context.AvailableNeighborSelectors)
                               .Using(BindingFlow.OneWay));

            _firstNumericEnabled = NumericEnabled(firstNumeric);
            _carvingNumericEnabled = NumericEnabled(carvingNumeric);
            _leftNumericEnabled = NumericEnabled(leftNumeric);

            FirstCellParameterAvailable.ValueChanged += _firstNumericEnabled;
            CarvingCellParameterAvailable.ValueChanged += _carvingNumericEnabled;
            LeftCellParameterAvailable.ValueChanged += _leftNumericEnabled;

            FirstCellParameter.ValueChanged += OnFirstCellParameterValueChange;
            CarvingCellParameter.ValueChanged += OnCarvingCellParameterValueChange;
            LeftCellParameter.ValueChanged += OnLeftCellParameterValueChange;
            AvailableCellSelectors.ValueChanged += OnAvailableCellSelectorsChange;
            AvailableNeighborSelectors.ValueChanged += OnAvailableNeighborSelectorChange;

            firstCellList.SelectedValueChanged += FirstCellListOnSelectedValueChanged;
            carvingCellList.SelectedValueChanged += CarvingCellListOnSelectedValueChanged;
            leftCellList.SelectedValueChanged += LeftCellListOnSelectedValueChanged;
            neighborCellList.SelectedValueChanged += NeighborCellListOnSelectedValueChanged;

            firstNumeric.ValueChanged += FirstNumericOnValueChanged;
            carvingNumeric.ValueChanged += CarvingNumericOnValueChanged;
            leftNumeric.ValueChanged += LeftNumericOnValueChanged;
        }

        private PropertyChanged<bool> NumericEnabled(NumericUpDown numericUpDown)
        {
            return (value, previous) => numericUpDown.Enabled = value;
        }

        private void OnFirstCellParameterValueChange(float v, float p)
        {
            firstNumeric.Value = (decimal)v;
        }

        private void OnCarvingCellParameterValueChange(float v, float p)
        {
            carvingNumeric.Value = (decimal)v;
        }

        private void OnLeftCellParameterValueChange(float v, float p)
        {
            leftNumeric.Value = (decimal)v;
        }

        private void OnAvailableCellSelectorsChange(IEnumerable<CellSelector> current,
                                                    IEnumerable<CellSelector> previous)
        {
            firstCellList.DataSource = current.ToArray();
            carvingCellList.DataSource = current.ToArray();
            leftCellList.DataSource = current.ToArray();
        }

        private void OnAvailableNeighborSelectorChange(IEnumerable<NeighborSelector> current,
                                                       IEnumerable<NeighborSelector> previous)
        {
            neighborCellList.DataSource = current.ToArray();
        }

        private void FirstNumericOnValueChanged(object sender, EventArgs e)
        {
            FirstCellParameter.Set((float)firstNumeric.Value);
        }

        private void LeftNumericOnValueChanged(object sender, EventArgs e)
        {
            LeftCellParameter.Set((float)leftNumeric.Value);
        }

        private void CarvingNumericOnValueChanged(object sender, EventArgs e)
        {
            CarvingCellParameter.Set((float)carvingNumeric.Value);
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

        private void CarvingCellListOnSelectedValueChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(carvingCellList.SelectedValue.ToString(), true, out CellSelector type))
            {
                CarvingCellSelector.Set(type);
            }
            else
            {
                CarvingCellSelector.Set(CellSelector.Random);
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
            FirstCellParameterAvailable.ValueChanged -= _firstNumericEnabled;
            CarvingCellParameterAvailable.ValueChanged -= _carvingNumericEnabled;
            LeftCellParameterAvailable.ValueChanged -= _leftNumericEnabled;

            FirstCellParameter.ValueChanged -= OnFirstCellParameterValueChange;
            CarvingCellParameter.ValueChanged -= OnCarvingCellParameterValueChange;
            LeftCellParameter.ValueChanged -= OnLeftCellParameterValueChange;
            AvailableCellSelectors.ValueChanged -= OnAvailableCellSelectorsChange;
            AvailableNeighborSelectors.ValueChanged -= OnAvailableNeighborSelectorChange;

            firstCellList.SelectedValueChanged -= FirstCellListOnSelectedValueChanged;
            carvingCellList.SelectedValueChanged -= CarvingCellListOnSelectedValueChanged;
            leftCellList.SelectedValueChanged -= LeftCellListOnSelectedValueChanged;
            neighborCellList.SelectedValueChanged -= NeighborCellListOnSelectedValueChanged;

            firstNumeric.ValueChanged -= FirstNumericOnValueChanged;
            carvingNumeric.ValueChanged -= CarvingNumericOnValueChanged;
            leftNumeric.ValueChanged -= LeftNumericOnValueChanged;
        }
    }
}