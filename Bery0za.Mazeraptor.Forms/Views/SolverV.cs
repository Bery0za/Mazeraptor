using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Forms.ViewModels;

namespace Bery0za.Mazerator.Forms.Views
{
    public class SolverV : IBindable<SolverVM>
    {
        public PropertyWrapper<bool> SolvingEnabled = new PropertyWrapper<bool>();
        public PropertyWrapper<IEnumerable<Cell>> Cells = new PropertyWrapper<IEnumerable<Cell>>(Enumerable.Empty<Cell>());
        public PropertyWrapper<Cell> SourceCell = new PropertyWrapper<Cell>();
        public PropertyWrapper<Cell> TargetCell = new PropertyWrapper<Cell>();
        public PropertyWrapper<SolverType> Type = new PropertyWrapper<SolverType>();
        public PropertyWrapper<IEnumerable<SolverType>> AvailableTypes = new PropertyWrapper<IEnumerable<SolverType>>();

        private GroupBox _solverBox;
        private ComboBox _solverList;
        private ComboBox _sourceCellList;
        private ComboBox _targetCellList;
        private Button _solveButton;

        private EventHandler _solveClickHandler;

        public SolverV(GroupBox solverBox, ComboBox solverList, ComboBox sourceCellList, ComboBox targetCellList, Button solveButton)
        {
            _solverBox = solverBox;
            _solverList = solverList;
            _sourceCellList = sourceCellList;
            _targetCellList = targetCellList;
            _solveButton = solveButton;
        }

        public void OnContextAttach(SolverVM context, IList<IBinding> bindings, IBinder<SolverVM> binder)
        {
            bindings.Add(Binder.Side(SolvingEnabled).To(context.SolvingEnabled).Using(BindingFlow.OneWay));
            bindings.Add(Binder.Side(Cells).To(context.Cells).Using(BindingFlow.OneWay));
            bindings.Add(Binder.Side(SourceCell).To(context.SourceCell).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(TargetCell).To(context.TargetCell).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(Type).To(context.Type).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(AvailableTypes).To(context.AvailableTypes).Using(BindingFlow.OneWay));

            SolvingEnabled.ValueChanged += OnSolvingEnabledValueChange;
            Cells.ValueChanged += OnCellsValueChange;
            AvailableTypes.ValueChanged += AvailableTypesOnValueChanged;

            _solverList.SelectedIndexChanged += SolverListOnSelectedIndexChanged;
            _sourceCellList.SelectedIndexChanged += SourceCellListOnSelectedIndexChanged;
            _targetCellList.SelectedIndexChanged += TargetCellListOnSelectedIndexChanged;
            _solveClickHandler = (s, e) => context.Solve();
            _solveButton.Click += _solveClickHandler;
        }

        private void SolverListOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SolvingEnabled.Value) Type.Set(AvailableTypes.Value.ElementAt(_solverList.SelectedIndex));
        }

        private void OnSolvingEnabledValueChange(bool value, bool previousValue)
        {
            _solverBox.Enabled = value;
            _solveButton.Enabled = value;
            _solveButton.Text = value ? "Solve" : "Maze is not generated yet";
        }

        private void OnCellsValueChange(IEnumerable<Cell> value, IEnumerable<Cell> previousvalue)
        {
            if (SolvingEnabled.Value)
            {
                _sourceCellList.DataSource = value.ToArray();
                _targetCellList.DataSource = value.ToArray();
            }
        }

        private void AvailableTypesOnValueChanged(IEnumerable<SolverType> value, IEnumerable<SolverType> previousvalue)
        {
            _solverList.DataSource = value.ToArray();
        }

        private void SourceCellListOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SolvingEnabled.Value) SourceCell.Set(Cells.Value.ElementAt(_sourceCellList.SelectedIndex));
        }

        private void TargetCellListOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SolvingEnabled.Value) TargetCell.Set(Cells.Value.ElementAt(_targetCellList.SelectedIndex));
        }

        public void OnContextDestroy()
        {
            SolvingEnabled.ValueChanged -= OnSolvingEnabledValueChange;
            Cells.ValueChanged -= OnCellsValueChange;
            AvailableTypes.ValueChanged -= AvailableTypesOnValueChanged;

            _solverList.SelectedIndexChanged -= SolverListOnSelectedIndexChanged;
            _sourceCellList.SelectedIndexChanged -= SourceCellListOnSelectedIndexChanged;
            _targetCellList.SelectedIndexChanged -= TargetCellListOnSelectedIndexChanged;
            if (_solveClickHandler != null) _solveButton.Click -= _solveClickHandler;
        }
    }
}
