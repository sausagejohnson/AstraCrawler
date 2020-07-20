using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace AstraCrawler.Domain
{
    public class HtmlElementScraper : IScraper
    {

        public ResultLinkInfo GetResult(string url, string xPathToResultText)
        {
            ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

WebRequest request = WebRequest.Create(url);
            request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:66.1) Gecko/20100101 Firefox/66.1");
            //request.Headers.Add("Accept-Language", "en-AU,en;q=0.5");
            request.Headers.Add("Referer", "https://www.carsales.com.au/cars/holden/astra/r-badge/bk-series/new-south-wales-state/hatch-bodystyle/manual-transmission/?sort=LastUpdated");
            request.Headers.Add("DNT", "1");
            //request.Headers.Add("Connection", "keep-alive");
            //request.Headers.Add("Upgrade-Insecure-Requests", "1");
            //request.Headers.Add("Cache-Control", "max-age=0, no-cache");
            //request.Headers.Add("Pragma", "no-cache");
            request.Headers.Add("Accept-Encoding", "deflate");
            request.Headers.Add("Host", "www.carsales.com.au");
            request.Method = "GET";
            request.Timeout = 1000000;
            ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:66.1) Gecko/20100101 Firefox/66.1";

            ResultLinkInfo resultInfo = new ResultLinkInfo()
            {
                Link = new Uri(url)
            };

            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();

            XmlDocument document = new XmlDocument();


            return resultInfo;
        }
    }
}
