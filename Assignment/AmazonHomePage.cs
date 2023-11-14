using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class AmazonHomePage
    {

        IWebDriver? driver;
        public void InitializeChromeDriver() 
        {

            driver = new ChromeDriver();      // initializing the chrome driver
            driver.Url = "https://www.amazon.com/"; // passing amazon web page url
         
        }
        public void TitleTest()
        {
            Thread.Sleep(2000); // delaying for 2 seconds

            Console.WriteLine("Title " + driver.Title);
           
            Assert.That(driver.Title.Contains("Amazon")); // checking whether the page is correctly loading .
            Console.WriteLine(" Amazon Title Test- Passed");// if title contains Amazon it will print Test is passed.

        }
        public void OrganisationTypeTest()
        {
            Thread.Sleep(3000); // delaying for 3 seconds
            Assert.That(driver.Url.Contains(".com")); // checking url contains .com
            Console.WriteLine(" Organisation Test- Passed");
        }
        public void Destruct()
        {
            driver.Close(); // closing the web page
        }
    }
}
