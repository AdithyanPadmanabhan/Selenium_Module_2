using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObjects
{
    internal class SearchResultsPage
    {


        IWebDriver driver;

        public SearchResultsPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);
           

        }
        // [FindsBy(How=How.XPath,Using ="//div[]@class='product-item-info-type3'")]

        [FindsBy(How = How.XPath,
         Using = "//*[@id=\"amasty-shopby-product-list\"]/div[2]/ol/li[1]/div/div[2]/strong/a[1]")]

        private IWebElement? FirstproductLink { get; set; }

        public string? GetFirstProductLink()
        {
            return FirstproductLink?.Text;
        }

        public ProductPage ClickFirstProductLink()
        {

            FirstproductLink?.Click();
            return  new ProductPage(driver);
        }
    }
}
