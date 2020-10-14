using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Forms.ViewModels;

namespace Bery0za.Mazerator.Forms.Views
{
    public partial class ProgressV : Form, IBindable<ProgressVM>
    {
        public PropertyWrapper<float> Progress = new PropertyWrapper<float>(0);
        public PropertyWrapper<bool> Started = new PropertyWrapper<bool>(false);
        public PropertyWrapper<bool> Canceled = new PropertyWrapper<bool>(false);
        public PropertyWrapper<bool> Finished = new PropertyWrapper<bool>(false);

        private Form _owner;

        public ProgressV(Form owner)
        {
            InitializeComponent();

            _owner = owner;
        }

        public void OnContextAttach(ProgressVM context, IList<IBinding> bindings, IBinder<ProgressVM> binder)
        {
            bindings.Add(Binder.Side(Progress).To(context.Progress).Using(BindingFlow.OneWay));
            bindings.Add(Binder.Side(Started).To(context.Started).Using(BindingFlow.OneWay));
            bindings.Add(Binder.Side(Canceled).To(context.Canceled).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(Finished).To(context.Finished).Using(BindingFlow.OneWay));

            Progress.ValueChanged += OnProgressValueChange;
            Started.ValueChanged += OnStartedValueChange;
            Finished.ValueChanged += OnFinishedValueChange;

            cancelButton.Click += CancelButtonOnClick;
        }

        private void OnProgressValueChange(float v, float pv)
        {
            progressBar.Value = (int)v;
        }

        private void OnStartedValueChange(bool v, bool pv)
        {
            if (v)
            {
                Show(_owner);
                _owner.Enabled = false;
            }
        }

        private void OnFinishedValueChange(bool v, bool pv)
        {
            if (v)
            {
                OnContextDestroy();
                Visible = false;
                _owner.Enabled = true;
                _owner.Focus();
            }
        }

        private void CancelButtonOnClick(object sender, EventArgs e)
        {
            Canceled.Set(true);
        }

        public void OnContextDestroy()
        {
            Progress.ValueChanged -= OnProgressValueChange;
            Started.ValueChanged -= OnStartedValueChange;
            Finished.ValueChanged -= OnFinishedValueChange;

            cancelButton.Click -= CancelButtonOnClick;
        }
    }
}