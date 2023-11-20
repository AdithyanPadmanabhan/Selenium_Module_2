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
        public void SearchProduct()
        {
           

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Product not found";

           

            IWebElement searchPrdouct = fluentWait.Until(d => d.FindElement(By.ClassName("Pke_EE")));
            searchPrdouct.SendKeys("laptop");
            searchPrdouct.SendKeys(Keys.Enter);
            //IWebElement searchButton = fluentWait.Until(d => d.FindElement(By.ClassName("_2iLD__")));
            //searchButton.Click();
            
        }
    }
}
