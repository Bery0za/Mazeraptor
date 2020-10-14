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
    public partial class RectanguarStructureV : UserControl, IBindable<RectangularStructureVM>, IStructureV
    {
        public PropertyWrapper<int> Width = new PropertyWrapper<int>(1);
        public PropertyWrapper<int> Height = new PropertyWrapper<int>(1);

        public RectanguarStructureV()
        {
            InitializeComponent();
        }

        public void OnContextAttach(RectangularStructureVM context,
                                    IList<IBinding> bindings,
                                    IBinder<RectangularStructureVM> binder)
        {
            bindings.Add(Binder.Side(Width).To(context.Width).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(Height).To(context.Height).Using(BindingFlow.TwoWay));

            Width.ValueChanged += OnWidthValueChange;
            Height.ValueChanged += OnHeightValueChange;

            widthNumeric.ValueChanged += WidthNumericOnValueChanged;
            heightNumeric.ValueChanged += HeightNumericOnValueChanged;
        }

        private void OnWidthValueChange(int v, int p)
        {
            widthNumeric.Value = v;
        }

        private void OnHeightValueChange(int v, int p)
        {
            heightNumeric.Value = v;
        }

        private void WidthNumericOnValueChanged(object sender, EventArgs e)
        {
            Width.Set((int)widthNumeric.Value);
        }

        private void HeightNumericOnValueChanged(object sender, EventArgs e)
        {
            Height.Set((int)heightNumeric.Value);
        }

        public void OnContextDestroy()
        {
            Width.ValueChanged -= OnWidthValueChange;
            Height.ValueChanged -= OnHeightValueChange;

            widthNumeric.ValueChanged -= WidthNumericOnValueChanged;
            heightNumeric.ValueChanged -= HeightNumericOnValueChanged;
        }
    }
}