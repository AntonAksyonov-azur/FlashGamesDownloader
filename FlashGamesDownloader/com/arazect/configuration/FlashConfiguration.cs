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
                            Regex = @"(/files/games/[A-Za-z0-9,-]+\.swf)",
                            SiteRoot = "http://armorgames.com",
                            SiteContentRoot = "http://armorgames.com",
                            ResultIsUrlEncoded = false
                        },
                    new FlashSiteEntry
                        {
                            SiteName = "Kongregate.com",
                            Regex = @"(http(%3A%2F%2F|:\/\/)chat\.kongregate\.com(%2F|\/)gamez[A-Za-z0-9-_%\.\/]+\.swf)",
                            SiteRoot = "http://www.kongregate.com",
                            SiteContentRoot = "",
                            ResultIsUrlEncoded = true
                        },
                    new FlashSiteEntry
                        {
                            SiteName = "Flashgames247.com",
                            Regex = @"\/games\/[A-Za-z0-9-_%\.\/]+\.swf)",
                            SiteRoot = "http://www.flashgames247.com",
                            SiteContentRoot = "http://www.flashgames247.com",
                            ResultIsUrlEncoded = false
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
        public bool ResultIsUrlEncoded;
    }
}