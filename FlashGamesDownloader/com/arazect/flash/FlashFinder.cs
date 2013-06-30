using System;
using System.Linq;
using System.Text.RegularExpressions;
using FlashGamesDownloader.com.arazect.configuration;

namespace FlashGamesDownloader.com.arazect.flash
{
    public class FlashFinder
    {
        public String FindSwf(String content, FlashSiteEntry entry)
        {
            var re = new Regex(entry.Regex);

            MatchCollection result = re.Matches(content);
            if (result.Count == 0)
            {
                return null;
            }

            return entry.ResultIsUrlEncoded
                       ? String.Format("{0}{1}", entry.SiteContentRoot, Uri.UnescapeDataString(result[0].ToString()))
                       : String.Format("{0}{1}", entry.SiteContentRoot, result[0]);
        }

        public FlashSiteEntry DetermineConfigurationEntry(FlashConfiguration config, String siteAddressString)
        {
            return config.Data.FirstOrDefault(entry => siteAddressString.StartsWith(entry.SiteRoot));
        }
    }
}