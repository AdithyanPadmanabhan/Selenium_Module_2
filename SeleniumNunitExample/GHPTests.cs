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
       // [Ignore("other")]
        [Test]
        [Order(0)]
       
        public void TitleTest()
        {
            Thread.Sleep(2000);

            Console.WriteLine("Title " + driver.Title);
            
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine(" Title Test- Passed");

        }
        //  [Ignore("other")]
        [Test]
        [Order(1)]
        public void GoogleSearchTest()
        {
            string? currentDirectory = Directory.GetParent(@"../../../").FullName;
            string? excelFilePath = currentDirectory + "\\InputData.xlsx";
            Console.WriteLine(excelFilePath);


            List<ExcelData> exceDataList = ExcelUtils.ReadExcelData(excelFilePath);

            foreach (var excelData in exceDataList) { 

            IWebElement searchInputTextBox = driver.FindElement(By.Id("APjFqb"));
            searchInputTextBox.SendKeys(excelData.SearchText);
            Thread.Sleep(3000);
            //IWebElement searchButton = driver.FindElement(By.Name("btnK"));
            IWebElement searchButton = driver.FindElement(By.ClassName("gNO89b"));
            searchButton.Click();
                // Assert.AreEqual("hp laptop - Google Search", driver.Title);

                Assert.That(driver.Title, Is.EqualTo(excelData.SearchText + " - Google Search"));
            Console.WriteLine(" GS test passed");

                driver.Navigate().GoToUrl("https://www.google.com/");

        }
        }
        [Ignore("other")]
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
