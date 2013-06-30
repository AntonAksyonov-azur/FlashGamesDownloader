using System;
using System.Windows.Forms;

namespace FlashGamesDownloader.com.arazect.utility
{
    public static class UtilityClass
    {
        public static bool CheckNullValue(Object content, String message, String caption = "Ошибка")
        {
            if (content == null)
            {
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
    }
}