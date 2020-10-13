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
    public interface IGeneratorV
    {

    }

    public class GeneratorSelectorV : IBindable<GeneratorSelectorVM>
    {
        public readonly BindableWrapper<IGeneratorVM> Generator = new BindableWrapper<IGeneratorVM>();
        public readonly PropertyWrapper<GeneratorType> Type = new PropertyWrapper<GeneratorType>();
        public readonly PropertyWrapper<IEnumerable<GeneratorType>> AvailableTypes = new PropertyWrapper<IEnumerable<GeneratorType>>();

        private FlowLayoutPanel _layout;
        private ComboBox _selector;
        private IGeneratorV _view;

        public GeneratorSelectorV(FlowLayoutPanel layout, ComboBox selector)
        {
            this._layout = layout;
            this._selector = selector;
        }

        public void OnContextAttach(GeneratorSelectorVM context, IList<IBinding> bindings, IBinder<GeneratorSelectorVM> binder)
        {
            Generator.Attaching += OnGeneratorAttaching;
            Generator.Destroying += OnGeneratorDestroying;

            bindings.Add(Binder.Side(AvailableTypes).To(context.AvailableTypes).Using(BindingFlow.OneWay));
            bindings.Add(Binder.Side(Type).To(context.Type).Using(BindingFlow.TwoWay));

            binder.AttachChild(context.Generator, Generator);

            _selector.SelectedValueChanged += SelectorOnSelectedValueChanged;

            AvailableTypes.ValueChanged += AvailableTypesOnValueChanged;
        }

        private void OnGeneratorAttaching(IGeneratorVM context, IBinder<IContextWrapper<IGeneratorVM>> binder)
        {
            switch (context)
            {
                case RecursiveBacktrackerGeneratorVM rbg:
                {
                    RecursiveBacktrackerGeneratorV v = new RecursiveBacktrackerGeneratorV();
                    binder.AttachChild(rbg, v);
                    _view = v;
                    _layout.Controls.Add(v);

                    break;
                }
                case GrowingTreeGeneratorVM gt:
                {
                    GrowingTreeGeneratorV v = new GrowingTreeGeneratorV();
                    binder.AttachChild(gt, v);
                    _view = v;
                    _layout.Controls.Add(v);

                    break;
                }
            }
        }

        private void OnGeneratorDestroying()
        {
            if (_view is Control control)
            {
                _layout.Controls.Remove(control);
                control.Dispose();
            }
        }

        private void SelectorOnSelectedValueChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(_selector.SelectedValue.ToString(), true, out GeneratorType type))
            {
                Type.Set(type);
            }
            else
            {
                Type.Set(GeneratorType.RecursiveBacktracker);
            }
        }
        
        private void AvailableTypesOnValueChanged(IEnumerable<GeneratorType> value, IEnumerable<GeneratorType> previous)
        {
            _selector.DataSource = value;
        }

        public void OnContextDestroy()
        {
            Generator.Attaching -= OnGeneratorAttaching;
            Generator.Destroying -= OnGeneratorDestroying;

            _selector.SelectedValueChanged -= SelectorOnSelectedValueChanged;

            AvailableTypes.ValueChanged -= AvailableTypesOnValueChanged;
        }
    }
}
