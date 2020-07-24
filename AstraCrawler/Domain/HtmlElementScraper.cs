using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AstraCrawler.Domain
{
    public class HtmlElementScraper : IScraper
    {
        //private WebHeaderCollection BuildHeaders(string headers)
        //{
        //    WebHeaderCollection collection = new WebHeaderCollection();
        //    string[] headerLines = headers.Split('\n');
        //    for (int x=0; x<headerLines.Length; x++)
        //    {
        //        string headerLine = headerLines[x];
        //        string[] headerPair = headerLine.Split(':');
        //        string headerName = headerPair[0].Trim();
        //        if (headerName != "User-Agent" && headerName != "Accept-Encoding")
        //        {
        //            collection.Add(headerPair[0].Trim(), headerPair[1].Trim());
        //        }
        //    }

        //    return collection;
        //}

        private WebHeaderCollection BuildHeaders(List<Header> headers)
        {
            WebHeaderCollection collection = new WebHeaderCollection();

            if (headers != null)
            {
                foreach (Header header in headers)
                {
                    if (header.Name != "User-Agent" && header.Name != "Accept-Encoding")
                        collection.Add(header.Name, header.Value);
                }
            }

            return collection;
        }


        public ResultLinkInfo GetResult(ScrapeInfo scrapeInfo)
        {
            ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            WebHeaderCollection headerCollection = BuildHeaders(scrapeInfo.Headers);

            WebRequest request = WebRequest.Create(scrapeInfo.Url);

            request.Headers = headerCollection;

            int random = DateTime.Now.Second;
            request.Headers.Add("User-Agent", $"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:{random}) Gecko/20100101 Firefox/{random}");
            request.Headers.Add("Accept-Encoding", "deflate"); //gzip, deflate, br

            request.Method = "GET";

            //request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();
            //HttpWebResponse r2 = (HttpWebResponse)response;

            Stream stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(stream);
            string html = reader.ReadToEnd();

            Parser parser = new Parser();
            string result = parser.ParseResultsFromHtml(html, scrapeInfo.XPath);

            ResultLinkInfo resultInfo = new ResultLinkInfo()
            {
                Name = scrapeInfo.Name,
                Link = new Uri(scrapeInfo.Url),
                ResultText = result
            };

            return resultInfo;

        }

    }
}
