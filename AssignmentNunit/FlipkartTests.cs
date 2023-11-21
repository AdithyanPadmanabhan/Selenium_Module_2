using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumNunitExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNunit
{
    [TestFixture]
    internal class FlipkartTests : CoreCodes
    {
        [Test]
        [Order(1)]
        public void SearchProductTest()
        {
           

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Product not found";

           

            IWebElement searchPrdouct = fluentWait.Until(d => d.FindElement(By.ClassName("Pke_EE")));
            searchPrdouct.SendKeys("laptop");
            searchPrdouct.SendKeys(Keys.Enter);
            
        }

        [Test]
        [Order(2)]
        public void AddToCartTest()
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Product not found";

            IWebElement lapTopSelection = fluentWait.Until(d => d.FindElement(By.XPath
                ("//div[@class='_2kHMtA'][1]")));
            lapTopSelection.Click();

            List<string> listWindow = driver.WindowHandles.ToList();

            string lastWindowhandle = "";
            foreach (var handle in listWindow)
            {

                driver.SwitchTo().Window(handle);
                Thread.Sleep(3000);

            }
         
            IWebElement addCartButton = fluentWait.Until(d => d.FindElement(
                By.XPath("//button[@class='_2KpZ6l _2U9uOA _3v1-ww']")));
                   addCartButton.Click();
            Thread.Sleep(3000);

            IWebElement Cart = fluentWait.Until(d => d.FindElement(
               By.XPath("//div[@class='YUhWwv']")));
            Cart.Click();
            Thread.Sleep(3000);
        }
    }
}
