using System.Collections.Generic;
using System.Windows.Forms;

using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Forms.ViewModels;

namespace Bery0za.Mazerator.Forms.Views
{
    public partial class AppV : Form, IBindable<AppVM>
    {
        public BindableWrapper<GeneratorVM> Generator = new BindableWrapper<GeneratorVM>();
        public BindableWrapper<SolverVM> Solver = new BindableWrapper<SolverVM>();
        public BindableWrapper<DrawerVM> Drawer = new BindableWrapper<DrawerVM>();
        public BindableWrapper<ProgressVM> Progress = new BindableWrapper<ProgressVM>();

        private GeneratorV _generatorV;
        private SolverV _solverV;
        private DrawerV _drawerV;
        private ProgressV _progressV;

        public AppV()
        {
            InitializeComponent();

            _generatorV = new GeneratorV(structureLayout,
                                         structureList,
                                         generatorLayout,
                                         generatorList,
                                         generateButton,
                                         seedTextBox,
                                         openFileDialog);

            _solverV = new SolverV(solverBox, solverList, sourceCellList, targetCellList, solveButton);

            _drawerV = new DrawerV(drawerBox,
                                   drawButton,
                                   strokeColorButton,
                                   strokeCheckBox,
                                   strokeWidthNumeric,
                                   fillColorButton,
                                   fillCheckBox,
                                   fillTypeList,
                                   cellSizeNumeric,
                                   autoDrawCheckBox,
                                   colorDialog,
                                   mazePicture,
                                   saveImageButton,
                                   saveFileDialog);

            _progressV = new ProgressV(this);
        }

        public void OnContextAttach(AppVM context, IList<IBinding> bindings, IBinder<AppVM> binder)
        {
            Generator.Attaching += OnGeneratorAttaching;
            Solver.Attaching += OnSolverAttaching;
            Drawer.Attaching += OnDrawerGeneratorAttaching;
            Progress.Attaching += OnProgressGeneratorAttaching;

            binder.AttachChild(context.Generator, Generator);
            binder.AttachChild(context.Solver, Solver);
            binder.AttachChild(context.Drawer, Drawer);
            binder.AttachChild(context.Progress, Progress);
        }

        private void OnGeneratorAttaching(GeneratorVM context, IBinder<IContextWrapper<GeneratorVM>> binder)
        {
            binder.AttachChild(context, _generatorV);
        }

        private void OnSolverAttaching(SolverVM context, IBinder<IContextWrapper<SolverVM>> binder)
        {
            binder.AttachChild(context, _solverV);
        }

        private void OnDrawerGeneratorAttaching(DrawerVM context, IBinder<IContextWrapper<DrawerVM>> binder)
        {
            binder.AttachChild(context, _drawerV);
        }

        private void OnProgressGeneratorAttaching(ProgressVM context, IBinder<IContextWrapper<ProgressVM>> binder)
        {
            binder.AttachChild(context, _progressV);
        }

        public void OnContextDestroy()
        {
            Generator.Attaching -= OnGeneratorAttaching;
            Solver.Attaching -= OnSolverAttaching;
            Drawer.Attaching -= OnDrawerGeneratorAttaching;
            Progress.Attaching -= OnProgressGeneratorAttaching;
        }
    }
}