using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    internal class RediffHomePage
    {
        IWebDriver driver;

        public RediffHomePage(IWebDriver? driver)
        { 
            this.driver = driver ?? throw new ArgumentException(nameof(driver));//checking driver if null and it is null it will throw exception
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How =How.LinkText,Using ="Create Account")]
        public IWebElement? CreateAccountLink { get; set; }


        [FindsBy(How = How.LinkText, Using = "Sign in")]

        public IWebElement? SigInLink { get; set; }
        //act
        //public void CreateAccountLinkClick()
        //{
        //    CreateAccountLink?.Click();
        //}
        public CreateAccountPage CreateAccountClick()
        {
            CreateAccountLink?.Click();
            return new CreateAccountPage(driver);
        }
        public SiginPage SigInClick()
        {
            SigInLink?.Click();
            return new SiginPage(driver);
        }

        //public void SignInLinkClick() { 
        //    SigInLink?.Click();  
        //}
    }
}
