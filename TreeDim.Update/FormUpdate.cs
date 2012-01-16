#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;
#endregion

namespace TreeDim.Update
{
    //Procesing
    //Remove previous download file
    //Download file
    //Unzip file contents to temp folder
    //Remove files from destination folder present in temp folder
    //Move unzipped files to destination folder
    //Remove download file
    //Remove temp folder
    public partial class FormUpdate : Form
    {
        #region Data members
        bool called = true;
        private string processToEnd = "";
        private string downloadFile = "";
        private string URL = "";
        private string destinationFolder = "";
        private string postProcessCommand = string.Empty;
        private BackgroundWorker _bw = new BackgroundWorker();
        private int _downloadedBytes = 0;
        #endregion

        delegate void SetLabelCallback(Label label, string text);

        public void SetLabel(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                SetLabelCallback d = new SetLabelCallback(SetLabel);
                label.Invoke(d, new object[] { label, text });
            }
            else
            {
                label.Text = text;
                label.Refresh();
                Invalidate();
            }
        }

        #region Constructor
        public FormUpdate()
        {
            InitializeComponent();
        }
        #endregion

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            Hide();
            if (called)
            {
                WindowState = FormWindowState.Normal;
                Show();

                _bw.WorkerReportsProgress = true;
                _bw.WorkerSupportsCancellation = true;

                _bw.DoWork += new DoWorkEventHandler(backgroundWorker);
                _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                _bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);

                if (!_bw.IsBusy)
                    _bw.RunWorkerAsync();
            }
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Value = e.ProgressPercentage;
            // show downloading message
            SetLabel(line1, string.Format(Properties.Resources.ID_DOWNLOADINGFILE, downloadFile, e.ProgressPercentage));
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                SetLabel(line1, Properties.Resources.ID_CANCELING);
                Thread.Sleep(1000);
            }
            else if (e.Error != null)
            {
                SetLabel(line1, Properties.Resources.ID_ERROROCCURRED);
                Thread.Sleep(1000);
            }
            else
            {
                string setupExePath = Path.Combine(destinationFolder, downloadFile);
                if (File.Exists(setupExePath))
                {
                    // launching setup ...
                    SetLabel(line1, string.Format(Properties.Resources.ID_LAUNCHINGSETUP, downloadFile));
                    Thread.Sleep(1000);
                    postDownload();
                }
            }
            Close();
        }

        private void backgroundWorker(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker bw = sender as BackgroundWorker;
                preDownload();

                if (called)
                {
                    WindowState = FormWindowState.Normal;
                    Show();

                    // killing process
                    SetLabel(line1, string.Format(Properties.Resources.ID_STOPPINGPROCESS, processToEnd));
                    Thread.Sleep(1000);

                    Process[] processes = Process.GetProcesses();
                    foreach (Process process in processes)
                    {
                        if (process.ProcessName == processToEnd)
                            process.Kill();
                    }
                }

                // download file
                webdata.bytesDownloaded += Bytesdownloaded;
                webdata.downloadFromWeb(URL, downloadFile, destinationFolder, sender, e);
            }
            catch (Exception /*ex*/)
            {
            }
        }

        private void unpackCommandline()
        {

            string cmdLn = "";

            foreach (string arg in Environment.GetCommandLineArgs())
            {
                cmdLn += arg;

            }

            if (cmdLn.IndexOf('|') == -1)
            {
                called = false;
                FormInfo info = new FormInfo();
                info.ShowDialog();
                Close();
            }


            string[] tmpCmd = cmdLn.Split('|');

            for (int i = 1; i < tmpCmd.GetLength(0); i++)
            {
                if (tmpCmd[i] == "downloadFile") downloadFile = tmpCmd[i + 1];
                if (tmpCmd[i] == "URL") URL = tmpCmd[i + 1];
                if (tmpCmd[i] == "destinationFolder") destinationFolder = tmpCmd[i + 1];
                if (tmpCmd[i] == "processToEnd") processToEnd = tmpCmd[i + 1];
                if (tmpCmd[i] == "command") postProcessCommand = tmpCmd[i + 1];
                i++;
            }
        }

        private void preDownload()
        {
            unpackCommandline();
        }

        private void postDownload()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Path.Combine(destinationFolder, downloadFile);
            startInfo.Arguments = postProcessCommand;
            Process.Start(startInfo);
        }

        private void wrapUp()
        {
            try
            {
                if (Directory.Exists(destinationFolder))
                    Directory.Delete(destinationFolder, true);
            }
            catch (Exception /* ex */)
            {
            }
        }

        #region WebData class bytesDownloaded event handler
        private void Bytesdownloaded(ByteArgs e)
        {
            try
            {
                _downloadedBytes += e.downloaded;
                int percentage = (_downloadedBytes * 100) / e.total;
                _bw.ReportProgress(percentage < 100 ? percentage : 100);
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
            }
        }
        #endregion

        private void bnCancel_Click(object sender, EventArgs e)
        {
            if (_bw.WorkerSupportsCancellation)
                _bw.CancelAsync();
        }
    }
}