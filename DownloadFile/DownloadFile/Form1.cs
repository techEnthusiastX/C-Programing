using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace DownloadFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        WebClient client;
        string filename;
        private void btnDownload_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text;

            if (!string.IsNullOrEmpty(url))
            {
                Thread thread = new Thread(() =>
                    {
                        Uri uri = new Uri(url);
                        filename = System.IO.Path.GetFileName(uri.AbsolutePath);
                        client.DownloadDataAsync(uri, Application.StartupPath + "/" + filename);
                    });
                thread.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new WebClient();
            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
        }
        private void Client_DownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download Completed !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string dir = Path.GetDirectoryName(Application.StartupPath + "/" + filename);
            System.Diagnostics.Process.Start("explorer",dir);

        }
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
 
        }
    }
}
