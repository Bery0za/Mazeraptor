using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;

namespace Bery0za.Mazerator.Forms.ViewModels
{
    public class GeneratorVM : ViewModel
    {
        public PropertyWrapper<Maze> Maze = new PropertyWrapper<Maze>(Mazerator.Maze.Empty);
        public PropertyWrapper<string> Seed = new PropertyWrapper<string>("Seed");

        public ContextWrapper<StructureSelectorVM> StructureSelector =
            new ContextWrapper<StructureSelectorVM>(new StructureSelectorVM());

        public ContextWrapper<GeneratorSelectorVM> GeneratorSelector =
            new ContextWrapper<GeneratorSelectorVM>(new GeneratorSelectorVM());

        public PropertyWrapper<ProgressVM> Progress = new PropertyWrapper<ProgressVM>(ProgressVM.Empty);

        public GeneratorVM() { }

        public void GenerateMaze()
        {
            Progress.Set(new ProgressVM(DoWork, RunWorkerCompleted));
            Progress.Value.Run();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            bool failed = false;

            Maze maze = new Maze(Seed.Value,
                                 StructureSelector.Value.CreateStructure(),
                                 GeneratorSelector.Value.CreateGenerator());

            maze.Generator.Stage += GeneratorOnStage;
            maze.Generate();
            maze.Generator.Stage -= GeneratorOnStage;

            if (!failed) e.Result = maze;

            void GeneratorOnStage(ProgressStage stage, IStructure structure, float percentage)
            {
                if (worker.CancellationPending && (stage == ProgressStage.Started || stage == ProgressStage.Ongoing))
                {
                    e.Cancel = true;
                    maze.Generator.Cancel();
                }

                switch (stage)
                {
                    case ProgressStage.Failed:
                        failed = true;
                        break;

                    case ProgressStage.Ongoing:
                        worker.ReportProgress((int)percentage);
                        break;
                }
            }
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Result is Maze maze)
            {
                Maze.Set(maze);
            }
            else
            {
                Maze.Set(Mazerator.Maze.Empty);
            }
        }

        public override IEnumerable<IContext> DefineChildren()
        {
            return new List<IContext>() { StructureSelector, GeneratorSelector };
        }
    }
}