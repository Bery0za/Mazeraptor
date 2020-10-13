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
    public partial class CircularStructureV : UserControl, IBindable<CircularStructureVM>, IStructureV
    {
        public PropertyWrapper<int> Rings = new PropertyWrapper<int>(1);
        public PropertyWrapper<float> Ratio = new PropertyWrapper<float>(1);

        public CircularStructureV()
        {
            InitializeComponent();
        }

        public void OnContextAttach(CircularStructureVM context, IList<IBinding> bindings, IBinder<CircularStructureVM> binder)
        {
            bindings.Add(Binder.Side(Rings).To(context.Rings).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(Ratio).To(context.Ratio).Using(BindingFlow.TwoWay));

            Rings.ValueChanged += RingsOnValueChanged;
            Ratio.ValueChanged += RatioOnValueChanged;

            ringsNumeric.ValueChanged += RingsNumericOnValueChange;
            ratioNumeric.ValueChanged += RatioNumericOnValueChange;
        }

        private void RingsNumericOnValueChange(object sender, EventArgs e)
        {
            Rings.Set((int)ringsNumeric.Value);
        }

        private void RatioNumericOnValueChange(object sender, EventArgs e)
        {
            Ratio.Set((float)ratioNumeric.Value);
        }

        private void RingsOnValueChanged(int v, int p)
        {
            ringsNumeric.Value = v;
        }

        private void RatioOnValueChanged(float v, float p)
        {
            ratioNumeric.Value = (decimal)v;
        }

        public void OnContextDestroy()
        {
            Rings.ValueChanged -= RingsOnValueChanged;
            Ratio.ValueChanged -= RatioOnValueChanged;

            ringsNumeric.ValueChanged += RingsNumericOnValueChange;
            ratioNumeric.ValueChanged += RatioNumericOnValueChange;
        }
    }
}
