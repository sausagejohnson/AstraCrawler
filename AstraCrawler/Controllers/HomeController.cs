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
            HtmlElementScraper scraper = new HtmlElementScraper();
            ResultLinkInfo info = scraper.GetResult(
                "https://www.carsales.com.au/cars/holden/astra/r-badge/bk-series/hatch-bodystyle/manual-transmission/?sort=LastUpdated",
                "/html/body/div[2]/div[3]/div[1]/div[1]/div[1]/div/h1"
                );

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
