using System;
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
            String str = GetHtmlSource(tbAddress.Text);

            if (str == null)
            {
                MessageBox.Show("Error! Failed to connect", "Error");
            }
            else
            {
                String sfwResult = FindSwf(str);
                if (sfwResult != null)
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(sfwResult, "file.swf");
                    MessageBox.Show("Done!", "Done!");
                }
            }
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
            StreamReader reader = new StreamReader(stream);

            String source = reader.ReadToEnd();

            return source;   
        }

        private String FindSwf(String content)
        {
            String regex = @"(/files/games/[A-Za-z0-9,-]+.swf)";
            Regex re = new Regex(regex);

            var result = re.Matches(content);
            if (result.Count == 0)
            {
                MessageBox.Show("Error! No matches", "Error");
                return null;
            }

            return String.Format("http://cache.armorgames.com{0}", result[0]);
        }
    }
}