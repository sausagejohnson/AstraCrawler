using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace AstraCrawler.Domain
{
    public class Parser
    {
        public string ParseResultsFromHtml(string html, string xpath)
        {
            if (html.Length == 0 || xpath.Length == 0)
            {
                return "Missing html or xpath";
            }

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            HtmlNode node = document.DocumentNode.SelectSingleNode(xpath);
            return node.InnerHtml;
        }
    }
}
