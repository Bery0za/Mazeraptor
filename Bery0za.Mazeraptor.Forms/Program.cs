using System;
using System.Diagnostics;
using System.Windows.Forms;

using Bery0za.Ariadne;
using Bery0za.Ariadne.Framework;
using Bery0za.Mazerator.Forms.ViewModels;
using Bery0za.Mazerator.Forms.Views;
using Bery0za.Mazerator.Solvers;
using Bery0za.Mazerator.Types;

namespace Bery0za.Mazerator.Forms
{
    internal sealed class Program
    {
        private static AppVM _app = new AppVM();
        private static Binder<AppVM> _binder;
        private static AppV _appV;

        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppV _appV = new AppV();
            _binder = new Binder<AppVM>(_app);
            _binder.Attach(_appV);
            _binder.Run();

            Application.Run(_appV);
        }
    }
}