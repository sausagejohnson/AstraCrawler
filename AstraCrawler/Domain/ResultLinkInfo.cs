using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstraCrawler.Domain
{
    public class ResultLinkInfo
    {
        public string Name { get; set; }
        public Uri Link { get; set; }
        public string ResultText { get; set; }
        public bool Success { get; set; }
    }
}
