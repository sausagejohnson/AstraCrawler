using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AstraCrawler.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AstraCrawler.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        // GET: api
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<ScrapeInfo> scrapeInfos = ScrapeInfo.LoadScrapeInfos();
            List<string> names = scrapeInfos.Select(x => x.Name).ToList();

            return names;
        }

        // GET: api/WayneJohnson
        [HttpGet("{name}", Name = "Get")]
        public ResultLinkInfo Get(string name)
        {
            List<ScrapeInfo> scrapeInfos = ScrapeInfo.LoadScrapeInfos();
            ScrapeInfo scrapeInfo = scrapeInfos.Where(x => x.Name == name).FirstOrDefault();

            HtmlElementScraper elementScraper = new HtmlElementScraper();

            ResultLinkInfo info = new ResultLinkInfo();
            info = elementScraper.GetResult(scrapeInfo);

            return info;
        }

        // POST: api/Api
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Api/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
