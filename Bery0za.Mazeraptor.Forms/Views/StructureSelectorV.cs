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
    public interface IStructureV
    {

    }

    public class StructureSelectorV : IBindable<StructureSelectorVM>
    {
        public readonly BindableWrapper<IStructureVM> Structure = new BindableWrapper<IStructureVM>();
        public readonly PropertyWrapper<StructureType> Type = new PropertyWrapper<StructureType>();
        public readonly PropertyWrapper<IEnumerable<StructureType>> AvailableTypes = new PropertyWrapper<IEnumerable<StructureType>>();

        private FlowLayoutPanel _layout;
        private ComboBox _selector;
        private IStructureV _view;

        private OpenFileDialog _loadDialog;

        public StructureSelectorV(FlowLayoutPanel layout, ComboBox selector, OpenFileDialog loadDialog)
        {
            _layout = layout;
            _selector = selector;
            _loadDialog = loadDialog;
        }

        public void OnContextAttach(StructureSelectorVM context, IList<IBinding> bindings, IBinder<StructureSelectorVM> binder)
        {
            Structure.Attaching += OnStructureAttaching;
            Structure.Destroying += OnStructureDestroying;

            bindings.Add(Binder.Side(AvailableTypes).To(context.AvailableTypes).Using(BindingFlow.OneWay));
            bindings.Add(Binder.Side(Type).To(context.Type).Using(BindingFlow.TwoWay));

            binder.AttachChild(context.Structure, Structure);

            AvailableTypes.ValueChanged += AvailableTypesOnValueChanged; 
            
            _selector.SelectedValueChanged += SelectorOnSelectedValueChanged;
        }

        private void OnStructureAttaching(IStructureVM context, IBinder<IContextWrapper<IStructureVM>> binder)
        {
            switch (context)
            {
                case RectangularStructureVM rp:
                {
                    RectanguarStructureV v = new RectanguarStructureV();
                    binder.AttachChild(rp, v);
                    _view = v;
                    _layout.Controls.Add(v);

                    break;
                }
                case CircularStructureVM cp:
                {
                    CircularStructureV v = new CircularStructureV();
                    binder.AttachChild(cp, v);
                    _view = v;
                    _layout.Controls.Add(v);

                    break;
                }
                case ShapedStructureVM sp:
                {
                    ShapedStructureV v = new ShapedStructureV(_loadDialog);
                    binder.AttachChild(sp, v);
                    _view = v;
                    _layout.Controls.Add(v);

                    break;
                }
            }
        }

        private void OnStructureDestroying()
        {
            if (_view is Control control)
            {
                _layout.Controls.Remove(control);
                control.Dispose();
            }
        }

        private void AvailableTypesOnValueChanged(IEnumerable<StructureType> current, IEnumerable<StructureType> previous)
        {
            _selector.DataSource = current.ToArray();
        }

        private void SelectorOnSelectedValueChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(_selector.SelectedValue.ToString(), true, out StructureType type))
            {
                Type.Set(type);
            }
            else
            {
                Type.Set(StructureType.Rectangular);
            }
        }

        public void OnContextDestroy()
        {
            Structure.Attaching += OnStructureAttaching;
            Structure.Destroying += OnStructureDestroying;

            AvailableTypes.ValueChanged -= AvailableTypesOnValueChanged;

            _selector.SelectedValueChanged -= SelectorOnSelectedValueChanged;
        }
    }
}
