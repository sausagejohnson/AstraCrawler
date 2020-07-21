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

        public ResultLinkInfo GetResult(string url, string xPathToResultText)
        {
            ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            WebRequest request = WebRequest.Create(url);

            int random = DateTime.Now.Second;

            request.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            request.Headers.Add("User-Agent", $"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:{random}) Gecko/20100101 Firefox/{random}");
            //request.Headers.Add("Accept-Language", "en-AU,en;q=0.5");
            request.Headers.Add("Referer", "https://www.drive.com.au/car-sales?search=1&sortBy=1&priceMax=50000&make=Holden&model=Astra&location=&yearMin=2016&yearMax=&kmsMin=&kmsMax=&seller=&seats=&doors=&transmission=manual&body=&fuel=&color=&driveType=&features=&keywords=");
            request.Headers.Add("DNT", "1");
            //request.Headers.Add("Connection", "keep-alive");
            //request.Headers.Add("Upgrade-Insecure-Requests", "1");
            //request.Headers.Add("Cache-Control", "max-age=0, no-cache");
            //request.Headers.Add("Pragma", "no-cache");

            request.Headers.Add("Accept-Encoding", "deflate"); //gzip, deflate, br
            request.Headers.Add("Host", "www.drive.com.au");
            request.Method = "GET";
            request.Timeout = 1000000;
            //((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:66.1) Gecko/20100101 Firefox/66.1";

            ResultLinkInfo resultInfo = new ResultLinkInfo()
            {
                Link = new Uri(url)
            };

            //request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();
            //HttpWebResponse r2 = (HttpWebResponse)response;

            Stream stream = response.GetResponseStream();
            //string html = "<html><body>Hello World</body></html>";
            

            StreamReader reader = new StreamReader(stream);
            string html = reader.ReadToEnd();
            File.WriteAllText("c:\\temp\\raw-html-output.txt", html);
            //string decodedHtml = System.Text.UTF8Encoding.Default.GetString()
            //StringBuilder builder = new StringBuilder();

            //byte[] bytes;
            //bytes.Append()

            //while (!reader.EndOfStream )
            //{
            //    bytes.Append((byte)reader.Read());
            //}


            //string html = builder.ToString();

            XmlDocument document = new XmlDocument();
            document.InnerXml = html;


            return resultInfo;
        }
    }
}
