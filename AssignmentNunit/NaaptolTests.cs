using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumNunitExample;

namespace AssignmentNunit
{
    internal class NaaptolTests : CoreCodes
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



            IWebElement searchPrdouct = fluentWait.Until(d => d.FindElement(By.Id("header_search_text")));
            searchPrdouct.SendKeys("eyewear");
            searchPrdouct.SendKeys(Keys.Enter);

        }

        [Test]
        [Order(2)]
        [TestCaseSource(nameof(ItemNumber))]
        public void AddToCartTest(string pId)
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Product not found";

            IWebElement eyeWearSelection = fluentWait.Until(d => d.FindElement(By.XPath
                ("//div[@id ='productItem"+ pId+"']")));
            eyeWearSelection.Click();
           

            List<string> listWindow = driver.WindowHandles.ToList();

          
            foreach (var handle in listWindow)
            {

                driver.SwitchTo().Window(handle);
                Thread.Sleep(3000);

            }
            IWebElement sizeSelection = fluentWait.Until(d => d.FindElement(By.XPath
               (" //a[text()= 'Black-2.50']")));
            sizeSelection.Click();


            IWebElement buyItem = fluentWait.Until(d => d.FindElement(By.Id("cart-panel-button-0")));
            buyItem.Click();
            Thread.Sleep(3000);



        }
        static object[] ItemNumber()
        {
            return new object[]
            {
                new object[] {"5"},
               
            };
        }
        [Test]
        [Order(3)]

        public void viewCart()
        {
            string url = "https://www.naaptol.com/eyewear/reading-glasses-with-led-lights-lrg4/p/12612074.html";
           IWebElement item = driver.FindElement(By.XPath("//a[contains(text(),'LRG4)')]"));
            Assert.AreEqual(url, item.GetAttribute("href"));
            

            //*[@id="cartData"]/li[1]/div[2]/h2/a
           
            
        }

    }
}
