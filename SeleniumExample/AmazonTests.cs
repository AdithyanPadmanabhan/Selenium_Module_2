using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExample
{
    internal class AmazonTests
    {

        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {

            driver = new EdgeDriver();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize(); //maximize window


        }
        public void InitializeChromeDriver()
        {

            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();

        }
        public void TitleTest()
        {
            Thread.Sleep(2000);

            Console.WriteLine("Title " + driver.Title);
           
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine(" Title Test- Passed");

        }
        public void LogoClickTest()
        {
            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine(" Logo click Test- Passed");
        }
        public void SerachProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(4000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That(("Amazon.com : mobiles".Equals(driver.Title)) && (driver.Url.Contains("mobiles")));
            Console.WriteLine("Search test passed");
        }
        public void ReloadHomePageTest()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com");
            Thread.Sleep(3000);



        }
        public void TodaysDealTest()
        {
           IWebElement todaysdeal = driver.FindElement(By.LinkText("Today's Deals"));
            if(todaysdeal == null)
            {
                throw new NoSuchElementException("Today's Deals link is not present");
            }
            todaysdeal.Click();
            Thread.Sleep(3000);
            Assert.That(driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deals"));
           
            Console.WriteLine("Today's Deal test passed");
        }
        public void SignInAccountListTest()
        {
            IWebElement helloSignin = driver.FindElement(By.Id( "nav-link-accountList-nav-line-1"));
            if(helloSignin == null)
            {
                throw new NoSuchElementException("Hello, sign in is not present");
            }
            IWebElement accountList = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
           if(accountList == null)
            {
                throw new NoSuchElementException("Hello, Account & List is not present");
            }
            Assert.That(helloSignin.Text.Equals("Hello, sign in"));
            Console.WriteLine("SignINLink test passed");

            Assert.That(accountList.Text.Equals("Account & Lists"));
            Console.WriteLine("Account & Lists is present -Link test passed");
            
        }
        public void SearchAndFilterProductByBrandTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile phones");//searching mobile phones
            Thread.Sleep(4000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click(); //clicking on search button

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/i")).Click();//clicking on motorola check box

            Thread.Sleep(3000);
           
 
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/input")).Selected); //checking whether checkbox is marked
            Thread.Sleep(3000);
            Console.WriteLine("Motorola Check box is selected");


          driver.FindElement(By.ClassName("a-expander-prompt")).Click(); // clicking "see more" option
           
            driver.FindElement(By.XPath("//*[@id=\"p_89/Apple\"]/span/a/div/label/i")).Click();//clicking checkbox
            Thread.Sleep(3000);
      
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Apple\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Apple Check box is selected");
        }

        public void SortBySelectTest()
        {
            IWebElement sortBy = driver.FindElement(By.ClassName("a-native-dropdown a-declarative"));
            SelectElement sortbyselect = (SelectElement)sortBy;
            sortbyselect.SelectByValue("1");
            Thread.Sleep(3000);
            Console.WriteLine(sortbyselect.SelectedOption);
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
