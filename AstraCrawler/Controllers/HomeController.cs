using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AstraCrawler.Models;
using AstraCrawler.Domain;

namespace AstraCrawler.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            DataListModel model = new DataListModel();
            return View(model);

        }

    }

    //public class HomeController : Controller
    //{

    //    public IActionResult Index()
    //    {
    //        bool onlyRunLastScraper = true;

    //        HtmlElementScraper elementScraper = new HtmlElementScraper();

    //        ResultLinkInfo info = new ResultLinkInfo();

    //        List<ScrapeInfo> scrapeInfos = ScrapeInfo.LoadScrapeInfos();
    //        for (int x = 0; x < scrapeInfos.Count(); x++)
    //        {
    //            if (onlyRunLastScraper)
    //            {
    //                x = scrapeInfos.Count() - 1;
    //            }
    //            info = elementScraper.GetResult(scrapeInfos[x]);
    //        }


    //        if (info != null)
    //        {
    //            return View(info);
    //        }
    //        return View();

    //    }

    //}
}
