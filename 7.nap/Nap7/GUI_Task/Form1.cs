using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace GUI_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void AddText(object o)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new MethodInvoker(() => { richTextBox1.AppendText(o + "\n"); }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ThreadPool.QueueUserWorkItem(o => { richTextBox1.AppendText("valami\n"); });
            ThreadPool.QueueUserWorkItem(AddText,"uj megoldas");
            //Task.Factory.StartNew(() => { richTextBox1.AppendText("valami\n"); });
            Task.Factory.StartNew(AddText,"uj megoldas");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task<int> t1 = new Task<int>(() =>GetTreadID() );
            Task<int> t2 = new Task<int>(() => GetTreadID());
            Task<int> t3 = new Task<int>(() => GetTreadID());
            Action<Task<int>[]> tfinish = tasks =>
            {
                foreach (var item in tasks)
                {
                    richTextBox1.AppendText(item.Result.ToString() + "\n");
                    //Application.DoEvents();
                }
            };
            Task.Factory.ContinueWhenAll<int>(new Task<int>[] { t1, t2, t3 }, tfinish,
                CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

            //t1.Start(); t2.Start(); t3.Start();

            Task fotask = Task.Factory.StartNew(
                () => { t1.Start(); t2.Start(); t3.Start(); },
                CancellationToken.None,
                TaskCreationOptions.None,
                TaskScheduler.FromCurrentSynchronizationContext()
                );


        }

        int GetTreadID()
        {
            Thread.Sleep(2000);
            return Thread.CurrentThread.ManagedThreadId;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = false;
                    e.Result = false;
                    return;
                }
                // muvelet
                Thread.Sleep(30);
                backgroundWorker1.ReportProgress(i);
            }
            e.Result = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

    }

}
