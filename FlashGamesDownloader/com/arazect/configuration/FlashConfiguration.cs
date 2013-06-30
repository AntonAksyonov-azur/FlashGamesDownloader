using System;
using System.Collections.Generic;

namespace FlashGamesDownloader.com.arazect.configuration
{
    public class FlashConfiguration : IConfigurationObject
    {
        public List<FlashSiteEntry> Data;

        public void InitDefault()
        {
            Data = new List<FlashSiteEntry>
                {
                    new FlashSiteEntry
                        {
                            SiteName = "Armor Games",
                            Regex = @"(/files/games/[A-Za-z0-9,-]+.swf)",
                            SiteRoot = "http://armorgames.com",
                            SiteContentRoot = "http://armorgames.com"
                        }
                };
        }
    }

    public class FlashSiteEntry
    {
        public String Regex;
        public String SiteRoot;
        public String SiteContentRoot;
        public String SiteName;
    }
}