using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Edge;

namespace SeleniumExample
{
    internal class GHPTests
    {

        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {

          driver = new EdgeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize(); //maximize window


        }
        public void InitializeChromeDriver()
        {

            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();

        }
        public void TitleTest()
        {
            Thread.Sleep(2000);
           
            Console.WriteLine("Title "+driver.Title);
           // Console.WriteLine("Title Lenth "+driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine(" Title Test- Passed");
        
        }
        public void PageSourceAndURLTest()
        {
           // Console.WriteLine("Page Source :"+ driver.PageSource);
            //Console.WriteLine("Page Source Length :"+ driver.PageSource.Length);
            //Console.WriteLine(driver.Url);
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine(" URL Test- Pass");
        }

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

        public void GmailLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Gmail")).Click();
           
            Thread.Sleep(3000);

            //  Assert.That(driver.Title.Contains("Gmail"));
            Assert.That(driver.Url.Contains("gmail"));
            Console.WriteLine(" Gmail link test passed");
        }
        public void ImagesLinkTest()
        {

            driver.Navigate().Back();

            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(3000);

   
            Assert.That(driver.Title.Contains("Images"));
            Console.WriteLine(" Image link test passed");
           
        }
        public void LocalizationTest()

        {

            driver.Navigate().Back();
            string local = driver.FindElement(By.XPath("/ html / body / div[1] / div[6] / div[1]")).Text;

            Thread.Sleep(4000);
            Assert.That(local.Equals("India"));
            Console.WriteLine(" Localization test passed");



        }
        public void GoogleAppYoutubeTest()
        {
            driver.FindElement(By.ClassName("gb_d")).Click();
            Thread.Sleep(4000);
            //   driver.FindElement(By.XPath("//*[@id=\'yDmH0d\']/c-wiz/div/div/c-wiz/div/div/div[2]/div[2]/div[1]/ul/li[4]/a/div/span")).Click();
            //  driver.FindElement(By.CssSelector("#yDmH0d > c-wiz > div > div > c-wiz > div > div > div.v7bWUd > div.o83JEf > div:nth-child(1) > ul > li:nth-child(4) > a > div > span")).Click();
            driver.FindElement(By.ClassName("tX9u1b")).Click();
            
            Thread.Sleep(4000);
            Assert.That("Youtube".Equals(driver.Title));


        }


        public void Destruct()
        {
            driver.Close();
        }
    }
}
