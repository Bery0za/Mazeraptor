using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Forms.ViewModels;
using Bery0za.Mazerator.Types;

namespace Bery0za.Mazerator.Forms.Views
{
    public class GeneratorV : IBindable<GeneratorVM>
    {
        public PropertyWrapper<string> Seed = new PropertyWrapper<string>();
        public BindableWrapper<StructureSelectorVM> StructureSelector = new BindableWrapper<StructureSelectorVM>();
        public BindableWrapper<GeneratorSelectorVM> GeneratorSelector = new BindableWrapper<GeneratorSelectorVM>();

        private FlowLayoutPanel _structureLayout;
        private ComboBox _structureList;
        private FlowLayoutPanel _generatorLayout;
        private ComboBox _generatorList;
        private Button _generateButton;
        private TextBox _seedTextBox;
        private OpenFileDialog _loadDialog;

        private StructureSelectorV _structureSelectorV;
        private GeneratorSelectorV _generatorSelectorV;

        private EventHandler _generateClickHandler;

        public GeneratorV(FlowLayoutPanel structureLayout, ComboBox structureList, FlowLayoutPanel generatorLayout, ComboBox generatorList, Button generateButton, TextBox seedTextBox, OpenFileDialog loadDialog)
        {
            _structureLayout = structureLayout;
            _structureList = structureList;
            _generatorLayout = generatorLayout;
            _generatorList = generatorList;
            _generateButton = generateButton;
            _seedTextBox = seedTextBox;
            _loadDialog = loadDialog;

            _structureSelectorV = new StructureSelectorV(structureLayout, structureList, _loadDialog);
            _generatorSelectorV = new GeneratorSelectorV(generatorLayout, generatorList);
        }

        public void OnContextAttach(GeneratorVM context, IList<IBinding> bindings, IBinder<GeneratorVM> binder)
        {
            StructureSelector.Attaching += OnStructureSelectorAttaching;
            GeneratorSelector.Attaching += OnGeneratorSelectorAttaching;

            bindings.Add(Binder.Side(Seed).To(context.Seed).Using(BindingFlow.TwoWay));

            binder.AttachChild(context.StructureSelector, StructureSelector);
            binder.AttachChild(context.GeneratorSelector, GeneratorSelector);

            Seed.ValueChanged += SeedOnValueChanged;

            _generateClickHandler = (s, e) => context.GenerateMaze();
            _generateButton.Click += _generateClickHandler;
            _seedTextBox.TextChanged += SeedTextBoxOnTextChanged;
        }

        private void OnStructureSelectorAttaching(StructureSelectorVM context, IBinder<IContextWrapper<StructureSelectorVM>> binder)
        {
            binder.AttachChild(context, _structureSelectorV);
        }

        private void OnGeneratorSelectorAttaching(GeneratorSelectorVM context, IBinder<IContextWrapper<GeneratorSelectorVM>> binder)
        {
            binder.AttachChild(context, _generatorSelectorV);
        }

        private void SeedOnValueChanged(string value, string previousValue)
        {
            _seedTextBox.Text = value;
        }

        private void SeedTextBoxOnTextChanged(object sender, EventArgs e)
        {
            Seed.Set(_seedTextBox.Text);
        }

        public void OnContextDestroy()
        {
            StructureSelector.Attaching -= OnStructureSelectorAttaching;
            GeneratorSelector.Attaching -= OnGeneratorSelectorAttaching;

            if (_generateClickHandler != null) _generateButton.Click -= _generateClickHandler;
            _seedTextBox.TextChanged -= SeedTextBoxOnTextChanged;
        }
    }
}
