using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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

                //if no Accept-Encoding is supplied deflate by default
                if (headers.Any(h => h.Name == "Accept-Encoding"))
                {
                    collection.Add("Accept-Encoding", "deflate"); //gzip, deflate, br
                }
            }

            return collection;
        }


        public ResultLinkInfo GetResult(ScrapeInfo scrapeInfo)
        {
            ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            WebHeaderCollection headerCollection = BuildHeaders(scrapeInfo.Headers);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(scrapeInfo.Url);


            request.Headers = headerCollection;

            int random = DateTime.Now.Second;
            request.Headers.Add("User-Agent", $"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:{random}) Gecko/20100101 Firefox/{random}");

            request.Method = "GET";
            request.Timeout = 10000;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            //request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            WebResponse response;
            try
            {
                response = request.GetResponse();
            } catch
            {
                ResultLinkInfo info404 = new ResultLinkInfo()
                {
                    Name = scrapeInfo.Name,
                    Success = false
                };

                return info404;
            }
              

            Stream stream = response.GetResponseStream();
            //stream = new GZipStream(stream, CompressionMode.Decompress);
            //stream = new DeflateStream(stream, CompressionMode.Decompress);

            StreamReader reader = new StreamReader(stream);
            string html = reader.ReadToEnd();


            Parser parser = new Parser();
            string result = parser.ParseResultsFromHtml(html, scrapeInfo.XPath);

            ResultLinkInfo resultInfo = new ResultLinkInfo()
            {
                Name = scrapeInfo.Name,
                Link = new Uri(scrapeInfo.Url),
                ResultText = result,
                Success = DetermineSuccess(scrapeInfo, result)
            };

            return resultInfo;

        }


        public bool DetermineSuccess(ScrapeInfo info, string html) //consider private
        {
            bool success = false;

            if (info.SuccessIndicator != null)
            {
                success = html.Contains(info.SuccessIndicator);
            }
            else if (info.FailureIndicator != null)
            {
                success = !html.Contains(info.FailureIndicator);
            }

            return success;
        }

    }
}
