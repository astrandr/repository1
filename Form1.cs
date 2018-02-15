using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BackgroundWorkerUI
{
    public partial class Form1 : Form
    {
        private BackgroundWorker worker = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            worker.DoWork += new DoWorkEventHandler(Process);
            worker.ProgressChanged += new ProgressChangedEventHandler(OnStatusChange);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnWorkCompleted);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerAsync(null);
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            this.progressBar.Value = 0;
        }

        private void Process(object sender, DoWorkEventArgs args)
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(200);
                worker.ReportProgress(i);
                if (worker.CancellationPending) return;
            }
        }

        private void OnStatusChange(object sender, ProgressChangedEventArgs args)
        {
            this.progressBar.Value = args.ProgressPercentage;
        }

        private void OnWorkCompleted(object sender, RunWorkerCompletedEventArgs args)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            this.progressBar.Value = 0;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
        }
    }
}
