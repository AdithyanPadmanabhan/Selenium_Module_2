using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.PageObjects
{
    internal class SiginPage
    {
        IWebDriver driver;

        public SiginPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.Id, Using = "login1")]
        public IWebElement? UserNameText { get; set; }


        [FindsBy(How = How.Id, Using = "password")]

        public IWebElement? PasswordText { get; set; }

        [FindsBy(How = How.Name, Using = "remember")]

        public IWebElement? RememberCheckBox { get; set; }

        [FindsBy(How = How.Name, Using = "proceed")]

        public IWebElement? SiginButton { get; set; }


        



        //act


        public void TypeUsername(string un)
        {
            UserNameText?.SendKeys(un);

        }

        public void TypePassword(string pd)
        {
            PasswordText?.SendKeys(pd);

        }

        public void ClicRremeberCheckBox()
        {
            RememberCheckBox?.Click();
        }

        public void ClickSiginButton()
        {
            SiginButton?.Click();
        }
    }
}
