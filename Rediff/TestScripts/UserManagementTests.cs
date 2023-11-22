using Rediff.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserManagementTests :CoreCodes
    {

        ////Assert
        //[Test,Order(1), Category("Smoke Test")]
        //public void CreateAccountLinkTest()
        //{
        //   var homepage = new RediffHomePage(driver);
        //    driver.Navigate().GoToUrl("https://www.rediff.com/");
        //    homepage.CreateAccountLinkClick();
        //    Assert.That(driver.Url.Contains("register"));


        //}
        //[Test,Order(2),Category("Smoke Test")]
        //public void SignInLinkTest()
        //{
        //    var homepage = new RediffHomePage(driver);
        //    driver.Navigate().GoToUrl("https://www.rediff.com/");
        //    homepage.SignInLinkClick();
        //    Assert.That(driver.Url.Contains("login"));

        //}

        //[Test, Order(1), Category("Regression Test")]
        //public void CreateAccountTest()
        //{
        //    var homepage = new RediffHomePage(driver);
        //    if (!driver.Url.Equals("https://www.rediff.com/"))
        //    {
        //        driver.Navigate().GoToUrl("https://www.rediff.com/");
        //    }
        // var createaccountpage  =   homepage.CreateAccountClick();
        //    Thread.Sleep(10000);
        //    createaccountpage.FullNameType("Abc");
        //    createaccountpage.RediffMailType("@gmail");
        //    createaccountpage.CheckAvailabilityButtonClick();
        //    Thread.Sleep(2000);
        //    createaccountpage.CreateMyAccountButtonClick();


        //}


        [Test, Order(2), Category("Regression Test")]
        public void SigninTest()
        {
            var homepage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com/"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com/");
            }
            var siginPage = homepage.SigInClick();
            Thread.Sleep(10000);
            siginPage.TypeUsername("amal");
            siginPage.TypePassword("1234");
            siginPage.ClicRremeberCheckBox();
            Assert.False(siginPage?.RememberCheckBox?.Selected);
            Thread.Sleep(3000);
            siginPage?.ClickSiginButton();
            Assert.True(true);



        }

    }

}


