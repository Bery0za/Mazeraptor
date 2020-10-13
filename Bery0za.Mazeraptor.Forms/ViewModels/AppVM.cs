using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;

namespace Bery0za.Mazerator.Forms.ViewModels
{
    public class AppVM : ViewModel
    {
        public ContextWrapper<GeneratorVM> Generator = new ContextWrapper<GeneratorVM>(new GeneratorVM());
        public ContextWrapper<SolverVM> Solver = new ContextWrapper<SolverVM>(new SolverVM());
        public ContextWrapper<DrawerVM> Drawer = new ContextWrapper<DrawerVM>(new DrawerVM());
        public ContextWrapper<ProgressVM> Progress = new ContextWrapper<ProgressVM>(ProgressVM.Empty);
        
        public AppVM()
        {
            _bindings.Add(Binder.Side(Solver.Value.Maze).To(Generator.Value.Maze).Using(BindingFlow.OneWay));
            _bindings.Add(Binder.Side(Drawer.Value.Maze).To(Generator.Value.Maze).Using(BindingFlow.OneWay));
            _bindings.Add(Binder.Side(Drawer.Value.SolvedPath).To(Solver.Value.SolvedPath).Using(BindingFlow.OneWay));
            _bindings.Add(Binder.Side(Progress).To(Generator.Value.Progress).Using(BindingFlow.OneWay));
            _bindings.Add(Binder.Side(Progress).To(Solver.Value.Progress).Using(BindingFlow.OneWay));

            InitBindings();
        }

        public override IEnumerable<IContext> DefineChildren()
        {
            return new List<IContext>() { Generator, Solver, Drawer, Progress };
        }
    }
}
