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
    public class ProgressVM : ViewModel
    {
        public static ProgressVM Empty = new ProgressVM((o, e) => { }, (o, e) => { });

        public PropertyWrapper<float> Progress = new PropertyWrapper<float>(0);
        public PropertyWrapper<bool> Started = new PropertyWrapper<bool>(false);
        public PropertyWrapper<bool> Canceled = new PropertyWrapper<bool>(false);
        public PropertyWrapper<bool> Finished = new PropertyWrapper<bool>(false);

        private BackgroundWorker _worker = new BackgroundWorker()
            { WorkerReportsProgress = true, WorkerSupportsCancellation = true };

        private DoWorkEventHandler _doWork;
        private RunWorkerCompletedEventHandler _runWorkerCompleted;

        public ProgressVM(DoWorkEventHandler doWork, RunWorkerCompletedEventHandler runWorkerCompleted)
        {
            _doWork = doWork;
            _runWorkerCompleted = runWorkerCompleted;

            Canceled.ValueChanged += OnCancelChange;
        }

        public void Run()
        {
            Started.Set(true);
            Finished.Set(false);

            _worker.DoWork += _doWork;
            _worker.ProgressChanged += WorkerOnProgressChanged;
            _worker.RunWorkerCompleted += RunWorkerCompleted;

            _worker.RunWorkerAsync();
        }

        private void OnCancelChange(bool current, bool previous)
        {
            if (current)
            {
                _worker.CancelAsync();
            }
        }

        private void WorkerOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress.Set((float)e.ProgressPercentage);
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Started.Set(false);
            Progress.Set(0);
            Canceled.Set(false);
            Finished.Set(true);

            _worker.DoWork -= _doWork;
            _worker.ProgressChanged -= WorkerOnProgressChanged;
            _worker.RunWorkerCompleted -= RunWorkerCompleted;

            _runWorkerCompleted(sender, e);
        }

        public override void Destroy()
        {
            Canceled.ValueChanged -= OnCancelChange;
        }
    }
}