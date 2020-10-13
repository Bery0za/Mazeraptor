using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Forms.ViewModels;

namespace Bery0za.Mazerator.Forms.Views
{
    public partial class ShapedStructureV : UserControl, IBindable<ShapedStructureVM>, IStructureV
    {
        public PropertyWrapper<InteriorSelector> Type = new PropertyWrapper<InteriorSelector>(ViewModels.InteriorSelector.Alpha);
        public PropertyWrapper<IEnumerable<InteriorSelector>> AvailableTypes = new PropertyWrapper<IEnumerable<InteriorSelector>>();

        private OpenFileDialog _loadImageDialog;

        private EventHandler _loadClickHandler;

        public ShapedStructureV(OpenFileDialog loadImageDialog)
        {
            InitializeComponent();

            _loadImageDialog = loadImageDialog;
        }

        public void OnContextAttach(ShapedStructureVM context, IList<IBinding> bindings, IBinder<ShapedStructureVM> binder)
        {
            bindings.Add(Binder.Side(Type).To(context.Type).Using(BindingFlow.TwoWay));
            bindings.Add(Binder.Side(AvailableTypes).To(context.AvailableTypes).Using(BindingFlow.TwoWay));

            AvailableTypes.ValueChanged += AvailableTypesOnValueChanged;

            _loadClickHandler = (s, e) => LoadImageButtonOnClick(context);
            loadImageButton.Click += _loadClickHandler;
            shapeSelectorList.SelectedValueChanged += ShapeSelectorListOnSelectedValueChanged;
        }

        private void AvailableTypesOnValueChanged(IEnumerable<InteriorSelector> value, IEnumerable<InteriorSelector> previousvalue)
        {
            shapeSelectorList.DataSource = value.ToArray();}

        private void ShapeSelectorListOnSelectedValueChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(shapeSelectorList.SelectedValue.ToString(), true, out InteriorSelector type))
            {
                Type.Set(type);
            }
            else
            {
                Type.Set(InteriorSelector.Alpha);
            }
        }

        private void LoadImageButtonOnClick(ShapedStructureVM context)
        {
            if (_loadImageDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream;

                if ((stream = _loadImageDialog.OpenFile()) != null)
                {
                    context.Load(stream);
                    loadImageLabel.Text = _loadImageDialog.FileName;
                }
            }
        }

        public void OnContextDestroy()
        {
            AvailableTypes.ValueChanged -= AvailableTypesOnValueChanged;

            if (_loadClickHandler != null) loadImageButton.Click -= _loadClickHandler;
            shapeSelectorList.SelectedIndexChanged -= ShapeSelectorListOnSelectedValueChanged;
        }
    }
}
