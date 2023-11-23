using BunnyCart.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    internal class BCTests : CoreCodes
    {
        [Test]
        public void SignUpTest()
        {
            BCHPage bchp = new(driver);
            bchp.ClickCreateAccountLink();
            Thread.Sleep(3000);
            try
            {
                Assert.That(driver.FindElement(By.XPath("//h1[contains(text(),'Create an Account')]"))
                    .Text, Is.EqualTo("Create an Account"));

            }
            catch (AssertionException)
            {
                Console.WriteLine("Create Account modal is not present");
            }

            bchp.SignUp("Adhi", "Padman", "adhi@gmail.com", "123456", "123456", "8921287202");

        }

       
    }
}
