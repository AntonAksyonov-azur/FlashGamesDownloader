using System.Windows.Forms;

namespace FlashGamesDownloader.com.arazect.utility
{
    public class FormMethodInvoker
    {
        private readonly Form _form;

        public FormMethodInvoker(Form form)
        {
            _form = form;
        }

        public void DoOnUiThread(MethodInvoker d)
        {
            if (_form.InvokeRequired)
            {
                _form.Invoke(d);
            }
            else
            {
                d();
            }
        }
    }
}