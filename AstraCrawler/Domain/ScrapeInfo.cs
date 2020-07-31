using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AstraCrawler.Domain
{
    public class ScrapeInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string XPath { get; set; }
        public List<Header> Headers { get; set; }
        public string SuccessIndicator { get; set; }
        public string FailureIndicator { get; set; }

        static public List<ScrapeInfo> LoadScrapeInfos()
        {
            List<ScrapeInfo> scrapeInfos = new List<ScrapeInfo>();

            using (StreamReader sr = File.OpenText("Models\\data.json"))
            {
                string stringData = sr.ReadToEnd();
                scrapeInfos = JsonConvert.DeserializeObject<List<ScrapeInfo>>(stringData);
            }

            return scrapeInfos;

        }
    }

}
