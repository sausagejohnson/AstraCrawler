using AstraCrawler.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstraCrawler.Models
{
    public class DataListModel
    {
        public List<ResultLinkInfo> List {
            get {
                List<ScrapeInfo> scrapeInfos = ScrapeInfo.LoadScrapeInfos();
                List<ResultLinkInfo> infos = scrapeInfos.Select(x => new ResultLinkInfo() {
                    Link = new Uri(x.Url),
                    Name = x.Name
                }).ToList();

                return infos;
            }
        }
    }
}
