using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using FlashGamesDownloader.com.arazect.configuration;
using FlashGamesDownloader.com.arazect.flash;
using FlashGamesDownloader.com.arazect.network;
using FlashGamesDownloader.com.arazect.utility;

namespace FlashGamesDownloader
{
    public partial class FormMain : Form
    {
        private readonly FlashFinder _flashFinder = new FlashFinder();
        private readonly FormMethodInvoker _formMethodInvoker;
        private readonly WebRequestWrapper _webRequestWrapper = new WebRequestWrapper();
        private FlashConfiguration _flashConfiguration;

        public FormMain()
        {
            InitializeComponent();

            _formMethodInvoker = new FormMethodInvoker(this);
        }

        #region Configuration control

        private void FormMain_Load(object sender, EventArgs e)
        {
            _flashConfiguration = ConfigurationLoader.LoadConfiguration<FlashConfiguration>("config.xml");
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigurationLoader.SaveConfiguration(_flashConfiguration, "config.xml");
        }

        #endregion

        #region MenuStrip functions

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Background worker

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            String url = tbAddress.Text;

            SetStatusMessage("Соединяемся...");
            String content = _webRequestWrapper.GetHtmlPageSource(url);
            if (UtilityClass.CheckNullValue(content, "Ошибка подключения"))
            {
                backgroundWorker.CancelAsync();
                return;
            }

            SetStatusMessage("Проверяем записи в конфигурации...");
            FlashSiteEntry entry = _flashFinder.DetermineConfigurationEntry(_flashConfiguration, url);
            if (UtilityClass.CheckNullValue(entry, "Неизвестный сайт. Операция отклонена"))
            {
                backgroundWorker.CancelAsync();
                return;
            }

            SetStatusMessage("Ищем файл...");
            String swfResult = _flashFinder.FindSwf(content, entry.Regex, entry.SiteContentRoot);

            if (UtilityClass.CheckNullValue(swfResult, "Файл не найден!"))
            {
                backgroundWorker.CancelAsync();
                SetStatusMessage("Файл не найден");
                return;
            }

            SetStatusMessage("Файл найден...");

            var dr = DialogResult.No;
            _formMethodInvoker.DoOnUiThread(() => dr = saveFileDialog.ShowDialog());
            if (dr == DialogResult.OK)
            {
                SetStatusMessage("Качаем файл...");
                var webClient = new WebClient();
                webClient.DownloadFileAsync(new Uri(swfResult), String.Format("{0}", saveFileDialog.FileName));
                webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
            }
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _formMethodInvoker.DoOnUiThread(
                () =>
                    {
                        progressBar.Value = e.ProgressPercentage;
                        if (e.ProgressPercentage == 100)
                        {
                            SetStatusMessage("Файл скачан!");
                        }
                    });
        }

        #endregion

        #region Buttons

        private void btnFind_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        #endregion

        #region Additional functions

        private void SetStatusMessage(String message)
        {
            _formMethodInvoker.DoOnUiThread(() => tsslStatusText.Text = message);
        }

        #endregion
    }
}