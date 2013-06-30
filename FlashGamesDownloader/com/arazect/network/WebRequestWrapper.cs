using System;
using System.IO;
using System.Net;

namespace FlashGamesDownloader.com.arazect.network
{
    public class WebRequestWrapper
    {
        public String GetHtmlPageSource(String address)
        {
            WebRequest request = WebRequest.Create(address);
            request.Method = "GET";

            Stream stream = request.GetResponse().GetResponseStream();

            return stream == null 
                ? null
                : new StreamReader(stream).ReadToEnd();
        }
    }
}
