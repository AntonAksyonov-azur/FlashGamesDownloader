using System;
using System.IO;
using System.Net;

namespace FlashGamesDownloader.com.arazect.network
{
    public class WebRequestWrapper
    {
        public String GetHtmlPageSource(String address)
        {
            if (String.IsNullOrEmpty(address))
            {
                return null;
            }

            HttpWebResponse response;
            WebRequest request = WebRequest.Create(address);
            request.Method = "GET";
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception e)
            {
                return null;
            }
            var stream = response.GetResponseStream();
            
            return stream == null 
                ? null
                : new StreamReader(stream).ReadToEnd();
        }
    }
}
