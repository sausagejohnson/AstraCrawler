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
            HtmlElementScraper driveScraper = new HtmlElementScraper();
            ResultLinkInfo info = driveScraper.GetResult(
                "https://www.drive.com.au/car-sales?search=1&sortBy=1&priceMax=50000&make=Holden&model=Astra&location=&yearMin=2016&yearMax=&kmsMin=&kmsMax=&seller=&seats=&doors=&transmission=manual&body=&fuel=&color=&driveType=&features=&keywords=",
                //"https://waynejohnson.net",
                "/html/body/div[8]/div/main/div/div[1]/div[5]/div"
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
