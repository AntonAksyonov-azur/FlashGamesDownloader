using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FlashGamesDownloader
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private String GetHtmlSource(String address)
        {
            WebRequest request = WebRequest.Create(address);
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            if (stream == null)
            {
                return null;
            }
            var reader = new StreamReader(stream);

            String source = reader.ReadToEnd();

            return source;
        }

        private String FindSwf(String content)
        {
            String regex = @"(/files/games/[A-Za-z0-9,-]+.swf)";
            var re = new Regex(regex);

            MatchCollection result = re.Matches(content);
            if (result.Count == 0)
            {
                MessageBox.Show("Error! No matches", "Error");
                return null;
            }

            return String.Format("http://armorgames.com{0}", result[0]);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            tsslStatusText.Text = "Соединяемся...";
            String str = GetHtmlSource(tbAddress.Text);

            if (str == null)
            {
                MessageBox.Show("Error! Failed to connect", "Error");
                backgroundWorker.CancelAsync();
            }
            else
            {
                tsslStatusText.Text = "Ищем файл...";
                String sfwResult = FindSwf(str);
                if (sfwResult != null)
                {
                    tsslStatusText.Text = "Файл найден...";

                    DialogResult dr = DialogResult.No;
                    DoOnUIThread(() => dr = saveFileDialog.ShowDialog());
                    if (dr == DialogResult.OK)
                    {
                        tsslStatusText.Text = "Качаем файл...";
                        var webClient = new WebClient();
                        webClient.DownloadFileAsync(new Uri(sfwResult), String.Format("{0}", saveFileDialog.FileName));
                        //webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
                    }
                }
            }
        }

        private void DoOnUIThread(MethodInvoker d)
        {
            if (InvokeRequired) { Invoke(d); } else { d(); }
        }
    }
}