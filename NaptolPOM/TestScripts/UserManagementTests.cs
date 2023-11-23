using NaptolPOM;
using OpenQA.Selenium;
using Rediff.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserManagementTests : CoreCodes
    {

        
        [Test, Order(1), Category("Regression Test")]
        public void SearchProductTest()
        {
            var homepage = new NaptolHomePage (driver);
            if (!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");
            }
           var productList =  homepage.searchProductType("eyewear");
         var productPage =   productList.ClickProduct();

             List<string> listWindow = driver.WindowHandles.ToList();


            foreach (var handle in listWindow)
            {

                driver.SwitchTo().Window(handle);
                Thread.Sleep(3000);
            }

            productPage.SizeSelectionClick();
            productPage.AddTocartClick();
            Thread.Sleep(5000);
            string url = productPage.GetTitle();

            Assert.That(url, Is.EqualTo(driver.FindElement(By.XPath("//a[contains(text(),'LRG4)')]")).GetAttribute("href")));
            
           



        }

    }

}


