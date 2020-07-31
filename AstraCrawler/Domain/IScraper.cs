﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstraCrawler.Domain
{
    interface IScraper
    {
        /// <summary>
        /// Pass the url and an XPath string to the part of the
        /// XML, HTML or JSON that contains the results summary to display on the page.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="xPathToResultText"></param>
        /// <returns></returns>
        ResultLinkInfo GetResult(ScrapeInfo scrapeInfo);

        bool DetermineSuccess(ScrapeInfo info, string html);
    }
}
