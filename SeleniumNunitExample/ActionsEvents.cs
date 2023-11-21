using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExample
{
    internal class ActionsEvents : CoreCodes
    {

        [Test]
        public void HomeLinkTest()
        ///"html/body/div" +"/table/tbody/tr/td" +"/table/tbody/tr/td"+"/table/tbody/tr/td"+"/table/tbody/tr"

        {
            IWebElement homeLink =driver.FindElement(By.LinkText("Home"));
            IWebElement tdhomelink = driver.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr/td[1]/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[1]"));
            Actions actions = new Actions(driver);
             Action mouseOverAction = () => actions.MoveToElement(homeLink).Build().Perform();
            Console.WriteLine("before : " + tdhomelink.GetCssValue("background-color"));
            mouseOverAction.Invoke();

            Console.WriteLine("After : " + tdhomelink.GetCssValue("background-color"));
        }
        [Test]
        public void multipleActiontest()
        {
            driver.Navigate().GoToUrl("https://www.linkedin.com/");

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));

            Actions actions = new Actions(driver);
            Action upperCaseInput = () => actions
            .KeyDown(Keys.Shift)
            .SendKeys(emailInput,"hello").KeyUp(Keys.Shift)
            .Build().Perform();
            upperCaseInput.Invoke();
            Console.WriteLine("text is :" + emailInput.GetAttribute("value"));
            Thread.Sleep(2000);

            


        }
    }
}
