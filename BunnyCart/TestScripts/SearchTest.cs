using BunnyCart.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    internal class SearchTest : CoreCodes
    {
      
        [Test]
        [TestCase("Water Poppy")]

        public void SearchProductAndAddToCart(string searchText)
        {
            BCHPage bchp = new(driver);
            var searchPage = bchp?.TypeSearchInput(searchText);

           // ScrollIntoView(driver, driver.FindElement(By.Id("password")));


            Assert.That(searchText.Contains(searchPage?.GetFirstProductLink()));
            var productPage = searchPage?.ClickFirstProductLink();

            //Assert.That(searchPage?.Equals(productPage?.GetProductTitleLabel()));
            string check = productPage?.GetProductUrl();
            Assert.That(check.Contains("Water-poppy"));

            productPage?.GetIncQtyLink();
            productPage?.ClickAddToCartButton();
            Thread.Sleep(3000);

            

        }
    }
}
