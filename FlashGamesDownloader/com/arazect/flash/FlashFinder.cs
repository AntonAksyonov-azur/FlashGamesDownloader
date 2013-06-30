using System;
using System.Linq;
using System.Text.RegularExpressions;
using FlashGamesDownloader.com.arazect.configuration;

namespace FlashGamesDownloader.com.arazect.flash
{
    public class FlashFinder
    {
        public String FindSwf(String content, String regex, String siteContentPath)
        {
            var re = new Regex(regex);

            MatchCollection result = re.Matches(content);
            return result.Count == 0
                       ? null
                       : String.Format("{0}{1}", siteContentPath, result[0]);
        }

        public FlashSiteEntry DetermineConfigurationEntry(FlashConfiguration config, String siteAddressString)
        {
            return config.Data.FirstOrDefault(entry => siteAddressString.StartsWith(entry.SiteRoot));
        }
    }
}