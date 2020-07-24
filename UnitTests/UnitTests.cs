using AstraCrawler.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GetResultsLineFromHtml()
        {
            using (StreamReader sr = File.OpenText("MockHtml.html"))
            {
                string html = sr.ReadToEnd();
                string xpath = "/html/body/div/div/div/h1";

                Parser parser = new Parser();
                string output = parser.ParseResultsFromHtml(html, xpath);

                Assert.AreEqual("10 Results that match.", output);
            }
        }

        [TestMethod]
        public void GetResultsLineFromDriveExampleHtml()
        {
            using (StreamReader sr = File.OpenText("DriveExample.html"))
            {
                string html = sr.ReadToEnd();
                string xpath = "/html/body/div[8]/div/main/div/div[1]/div[5]/div";

                Parser parser = new Parser();
                string output = parser.ParseResultsFromHtml(html, xpath);

                StringAssert.Contains(output, "Viewing");
            }
        }

    }
}
