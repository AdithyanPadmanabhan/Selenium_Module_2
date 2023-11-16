using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExample
{
    [TestFixture]
    internal class GHPTests : CoreCodes
    {
        [Test]
        [Order(0)]
       
        public void TitleTest()
        {
            Thread.Sleep(2000);

            Console.WriteLine("Title " + driver.Title);
            
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine(" Title Test- Passed");

        }
        [Test]
        [Order(1)]
        public void GoogleSearchTest()
        {
            IWebElement searchInputTextBox = driver.FindElement(By.Id("APjFqb"));
            searchInputTextBox.SendKeys("hp laptop");
            Thread.Sleep(3000);
            //IWebElement searchButton = driver.FindElement(By.Name("btnK"));
            IWebElement searchButton = driver.FindElement(By.ClassName("gNO89b"));
            searchButton.Click();
            Assert.AreEqual("hp laptop - Google Search", driver.Title);
            Console.WriteLine(" GS test passed");
        }
        [Test]
        public void CheckAllLinksStatusTest()
        {
            List<IWebElement> allLinks = driver.FindElements(By.TagName("a")).ToList();
            foreach (var link in allLinks)
            {
                string url = link.GetAttribute("href");

                if (url == null)
                {
                    Console.WriteLine("URL is null");
                    continue;
                }
                else
                {
                  bool isWorking =  CheckLinkStatus(url);
                    if (isWorking)
                        Console.WriteLine(url + "  is working");
                    else
                        Console.WriteLine(url + "  is not working");
                }
            }
        }
    }
}
