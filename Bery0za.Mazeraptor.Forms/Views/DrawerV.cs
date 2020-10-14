using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Forms.Drawers;
using Bery0za.Mazerator.Forms.ViewModels;

namespace Bery0za.Mazerator.Forms.Views
{
    public class DrawerV : IBindable<DrawerVM>
    {
        public PropertyWrapper<bool> DrawingEnabled = new PropertyWrapper<bool>();
        public PropertyWrapper<bool> AutoDraw = new PropertyWrapper<bool>();
        public PropertyWrapper<Color> StrokeColor = new PropertyWrapper<Color>();
        public PropertyWrapper<bool> StrokeEnabled = new PropertyWrapper<bool>();
        public PropertyWrapper<float> StrokeWidth = new PropertyWrapper<float>();
        public PropertyWrapper<Color> FillColor = new PropertyWrapper<Color>();
        public PropertyWrapper<bool> FillEnabled = new PropertyWrapper<bool>();
        public PropertyWrapper<FillType> FillType = new PropertyWrapper<FillType>();
        public PropertyWrapper<float> CellSize = new PropertyWrapper<float>();
        public PropertyWrapper<IEnumerable<FillType>> AvailableFillTypes = new PropertyWrapper<IEnumerable<FillType>>();
        public PropertyWrapper<Bitmap> Bitmap = new PropertyWrapper<Bitmap>();

        private GroupBox _drawerBox;
        private Button _drawButton;
        private Button _strokeColorButton;
        private CheckBox _strokeEnabledCheckBox;
        private NumericUpDown _strokeWidthNumeric;
        private Button _fillColorButton;
        private CheckBox _fillEnabledCheckBox;
        private ComboBox _fillTypeList;
        private NumericUpDown _cellSizeNumeric;
        private CheckBox _autoDrawCheckBox;
        private ColorDialog _colorDialog;
        private PictureBox _pictureBox;
        private Button _saveImageButton;
        private SaveFileDialog _saveFileDialog;

        private EventHandler _drawClickHandler;
        private EventHandler _saveClickHandler;

        public DrawerV(GroupBox drawerBox,
                       Button drawButton,
                       Button strokeColorButton,
                       CheckBox strokeEnabledCheckBox,
                       NumericUpDown strokeWidthNumeric,
                       Button fillColorButton,
                       CheckBox fillEnabledCheckBox,
                       ComboBox fillTypeList,
                       NumericUpDown cellSizeNumeric,
                       CheckBox autoDrawCheckBox,
                       ColorDialog colorDialog,
                       PictureBox pictureBox,
                       Button saveImageButton,
                       SaveFileDialog saveFileDialog)
        {
            _drawerBox = drawerBox;
            _drawButton = drawButton;
            _strokeColorButton = strokeColorButton;
            _strokeEnabledCheckBox = strokeEnabledCheckBox;
            _strokeWidthNumeric = strokeWidthNumeric;
            _fillColorButton = fillColorButton;
            _fillEnabledCheckBox = fillEnabledCheckBox;
            _fillTypeList = fillTypeList;
            _cellSizeNumeric = cellSizeNumeric;
            _autoDrawCheckBox = autoDrawCheckBox;
            _colorDialog = colorDialog;
            _pictureBox = pictureBox;
            _saveImageButton = saveImageButton;
            _saveFileDialog = saveFileDialog;
        }

        public void OnContextAttach(DrawerVM context, IList<IBinding> bindings, IBinder<DrawerVM> binder)
        {
            bindings.Add(Binder.Side(DrawingEnabled).To(context.DrawingEnabled).Using(BindingFlow.OneWay));
            bindings.Add(Binder.Side(AutoDraw).To(context.AutoDraw).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(StrokeColor).To(context.StrokeColor).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(StrokeEnabled).To(context.StrokeEnabled).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(StrokeWidth).To(context.StrokeWidth).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(FillColor).To(context.FillColor).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(FillEnabled).To(context.FillEnabled).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(FillType).To(context.FillType).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(CellSize).To(context.CellSize).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(AvailableFillTypes).To(context.AvailableFillTypes).Using(BindingFlow.OneWay));
            bindings.Add(Binder.Side(Bitmap).To(context.Bitmap).Using(BindingFlow.OneWay));

            DrawingEnabled.ValueChanged += DrawingEnabledOnValueChanged;
            StrokeColor.ValueChanged += OnStrokeColorValueChange;
            StrokeEnabled.ValueChanged += OnStrokeEnabledValueChange;
            StrokeWidth.ValueChanged += OnStrokeWidthValueChange;
            FillColor.ValueChanged += OnFillColorValueChange;
            FillEnabled.ValueChanged += OnFillEnabledValueChange;
            CellSize.ValueChanged += OnCellSizeValueChange;
            AvailableFillTypes.ValueChanged += OnAvailableFillTypesChange;
            Bitmap.ValueChanged += BitmapOnValueChanged;

            _strokeColorButton.Click += StrokeColorButtonOnClick;
            _strokeEnabledCheckBox.CheckedChanged += StrokeEnabledCheckBoxOnCheckedChanged;
            _strokeWidthNumeric.ValueChanged += StrokeWidthNumericOnValueChanged;
            _fillColorButton.Click += FillColorButtonOnClick;
            _fillEnabledCheckBox.CheckedChanged += FillEnabledCheckBoxOnEnabledChanged;
            _fillTypeList.SelectedValueChanged += FillTypeListOnSelectedValueChanged;
            _cellSizeNumeric.ValueChanged += CellSizeNumericOnValueChanged;
            _autoDrawCheckBox.CheckedChanged += AutoDrawCheckBoxOnCheckedChanged;
            _drawClickHandler = (s, e) => context.Draw();
            _drawButton.Click += _drawClickHandler;
            _saveClickHandler = (s, e) => SaveButtonOnClick(context);
            _saveImageButton.Click += _saveClickHandler;
        }

        private void DrawingEnabledOnValueChanged(bool value, bool previousvalue)
        {
            _drawerBox.Enabled = value;
            _drawButton.Enabled = value;
            _saveImageButton.Enabled = value;
            _drawButton.Text = value ? "Draw" : "Maze is not generated yet";
            _saveImageButton.Text = value ? "Save Image" : "Maze is not generated yet";
        }

        private void OnStrokeColorValueChange(Color v, Color pv)
        {
            _strokeColorButton.BackColor = v;
        }

        private void OnStrokeEnabledValueChange(bool v, bool pv)
        {
            _strokeEnabledCheckBox.Checked = v;
        }

        private void OnStrokeWidthValueChange(float v, float pv)
        {
            _strokeWidthNumeric.Value = (decimal)v;
        }

        private void OnFillColorValueChange(Color v, Color pv)
        {
            _fillColorButton.BackColor = v;
        }

        private void OnFillEnabledValueChange(bool v, bool pv)
        {
            _fillEnabledCheckBox.Checked = v;
        }

        private void OnCellSizeValueChange(float v, float pv)
        {
            _cellSizeNumeric.Value = (decimal)v;
        }

        private void OnAvailableFillTypesChange(IEnumerable<FillType> current, IEnumerable<FillType> previous)
        {
            _fillTypeList.DataSource = current.ToArray();
        }

        private void BitmapOnValueChanged(Bitmap value, Bitmap previousValue)
        {
            _pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            _pictureBox.Image = value;
        }

        private void StrokeColorButtonOnClick(object sender, EventArgs e)
        {
            DialogResult result = _colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                StrokeColor.Set(_colorDialog.Color);
            }
        }

        private void StrokeEnabledCheckBoxOnCheckedChanged(object sender, EventArgs e)
        {
            StrokeEnabled.Set(_strokeEnabledCheckBox.Checked);
        }

        private void StrokeWidthNumericOnValueChanged(object sender, EventArgs e)
        {
            StrokeWidth.Set((float)_strokeWidthNumeric.Value);
        }

        private void FillColorButtonOnClick(object sender, EventArgs e)
        {
            DialogResult result = _colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FillColor.Set(_colorDialog.Color);
            }
        }

        private void FillEnabledCheckBoxOnEnabledChanged(object sender, EventArgs e)
        {
            FillEnabled.Set(_fillEnabledCheckBox.Checked);
        }

        private void FillTypeListOnSelectedValueChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(_fillTypeList.SelectedValue.ToString(), true, out FillType type))
            {
                FillType.Set(type);
            }
            else
            {
                FillType.Set(Drawers.FillType.Solid);
            }
        }

        private void CellSizeNumericOnValueChanged(object sender, EventArgs e)
        {
            CellSize.Set((float)_cellSizeNumeric.Value);
        }

        private void AutoDrawCheckBoxOnCheckedChanged(object sender, EventArgs e)
        {
            AutoDraw.Set(_autoDrawCheckBox.Checked);
        }

        private void SaveButtonOnClick(DrawerVM context)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream;

                if ((stream = _saveFileDialog.OpenFile()) != null)
                {
                    context.Save(stream);
                }
            }
        }

        public void OnContextDestroy()
        {
            DrawingEnabled.ValueChanged += DrawingEnabledOnValueChanged;
            StrokeColor.ValueChanged -= OnStrokeColorValueChange;
            StrokeEnabled.ValueChanged -= OnStrokeEnabledValueChange;
            StrokeWidth.ValueChanged -= OnStrokeWidthValueChange;
            FillColor.ValueChanged -= OnFillColorValueChange;
            FillEnabled.ValueChanged -= OnFillEnabledValueChange;
            CellSize.ValueChanged -= OnCellSizeValueChange;
            AvailableFillTypes.ValueChanged -= OnAvailableFillTypesChange;

            _strokeColorButton.Click -= StrokeColorButtonOnClick;
            _strokeEnabledCheckBox.CheckedChanged -= StrokeEnabledCheckBoxOnCheckedChanged;
            _strokeWidthNumeric.ValueChanged -= StrokeWidthNumericOnValueChanged;
            _fillColorButton.Click -= FillColorButtonOnClick;
            _fillEnabledCheckBox.CheckedChanged -= FillEnabledCheckBoxOnEnabledChanged;
            _fillTypeList.SelectedValueChanged -= FillTypeListOnSelectedValueChanged;
            _cellSizeNumeric.ValueChanged -= CellSizeNumericOnValueChanged;
            if (_drawClickHandler != null) _drawButton.Click -= _drawClickHandler;
            if (_saveClickHandler != null) _saveImageButton.Click -= _saveClickHandler;
        }
    }
}