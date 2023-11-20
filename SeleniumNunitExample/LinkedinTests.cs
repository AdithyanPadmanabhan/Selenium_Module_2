using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExample
{
    [TestFixture]
    internal class LinkedinTests :CoreCodes
    {
        [Test]
        [Author("Adithyan","adhi@gmail.com")]
        [Description("Check for valid login")]
        [Category("Regression Testing")]

        
        public void Login1Test()
        {
           //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
          //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));





            //IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));

            //IWebElement passwordInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));// old format

            //IWebElement emailInput = wait.Until(d=>d.FindElement(By.Id("session_key")));// new format

            //IWebElement passwordInput = wait.Until(d => d.FindElement(By.Id("session_password")));


            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";




            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));// new format

            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));




            emailInput.SendKeys("abc@gmail.com");
            passwordInput.SendKeys("abc123");



           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        }
        //[Test]
        //[Author("Adithyan", "adhi@gmail.com")]
        //[Description("Check for Invalid login")]
        //[Category("Smoke Testing")]

        //public void Login2TestInvalidCredential()
        //{

        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(5);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //    fluentWait.Message = "Element not found";


        //    IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));// new format

        //    IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

        //    emailInput.SendKeys("abc@gmail.com");
        //    passwordInput.SendKeys("abc123");
        //    Thread.Sleep(3000);
        //    clearForm(emailInput);
        //    clearForm(passwordInput);

        //    emailInput.SendKeys("qwerc@gmail.com");
        //    passwordInput.SendKeys("qwer123");
        //    Thread.Sleep(3000);
        //    clearForm(emailInput);
        //    clearForm(passwordInput);

        //    emailInput.SendKeys("asdfg@gmail.com");
        //    passwordInput.SendKeys("123456");
        //    Thread.Sleep(3000);
        //    clearForm(emailInput);
        //    clearForm(passwordInput);

        //}
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }

        //[Test, Author("Amal", "amal@gmail.com")]

        //[Description("Check for Invalid login"), Category("Regression Testing")]
        //[TestCase("qwert@gmail.com","123456")]
        //[TestCase("q1234@gmail.com", "89456")]
        //[TestCase("sdfgt@gmail.com", "987")]

        //public void LoginTestWithInvalidCred(string email,string password)
        //{

        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(5);
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        //    fluentWait.Message = "Element not found";





        //    IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));// new format

        //    IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

        //    emailInput.SendKeys(email);
        //    passwordInput.SendKeys(password);
        //    ClearForm(emailInput);
        //    ClearForm(passwordInput);



        //}


        [Test, Author("Amal", "amal@gmail.com")]

        [Description("Check for Invalid login"), Category("Regression Testing")]
        [TestCaseSource(nameof(InvalidLogindata))]

        public void LoginTestWithInvalidCreds(string email, string password)
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));// new format

            IWebElement passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));

            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            ClearForm(emailInput);
            ClearForm(passwordInput);



        }
        static object[] InvalidLogindata()
        {
            return new object[]
            {
                new object[] {"aqwerty@gmail","12345"},
                new object[] {"zxcvbn@asd","09876"}
            };
        }

    }
}
