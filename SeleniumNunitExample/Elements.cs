using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExample
{
    [TestFixture]
    internal class Elements: CoreCodes
    {
        [Ignore("not correct")]
        [Test]
        public void TestCheckBox()
        {
            //IWebElement element = driver.FindElement(By.XPath("//h5[text() ='Elements']"));
            //Thread.Sleep(3000);
              //  element.Click();
            IWebElement cbmenu = driver.FindElement(By.XPath("//span[text() ='Check Box']"));
            cbmenu.Click();
           List< IWebElement> expandCollapse = driver.FindElements(
               By.ClassName("rct-collapse rct-collapse-btn")).ToList();
            foreach(var item  in expandCollapse)
            {
                item.Click();
            }
            IWebElement commandscheckbox = driver.FindElement(By.XPath("//span[text() ='Commands']"));
            commandscheckbox.Click();
            Assert.True(driver.FindElement(By.XPath("//input[contains(@id,'commands')]")).Selected);

        }
        [Test] public void TestFormElement()
        {
            Thread.Sleep(2000);
            IWebElement firstnameField = driver.FindElement(By.Id("firstName"));
            firstnameField.SendKeys("John");
            Thread.Sleep(2000);

            IWebElement lastnameField = driver.FindElement(By.Id("lastName"));
            lastnameField.SendKeys("samuel");
            Thread.Sleep(2000);

            IWebElement emailField = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            emailField.SendKeys("Johnsamuel@gmail");
            Thread.Sleep(2000);

            IWebElement genderradio = driver.FindElement(By.XPath("//input[@id='gender-radio-1']//following::label"));
            genderradio.Click();
            Thread.Sleep(2000);
            IWebElement mobileNumber = driver.FindElement(By.Id("userNumber"));
            mobileNumber.SendKeys("8934556781");
            Thread.Sleep(2000);

            IWebElement dateofbirthField = driver.FindElement(By.Id("dateOfBirthInput"));
            dateofbirthField.Click();
            Thread.Sleep(2000);

            IWebElement dateofbirthMonth = driver.FindElement(By.ClassName("react-datepicker__month-select"));
            SelectElement selectMonth = new SelectElement(dateofbirthMonth);
            selectMonth.SelectByIndex(5);
            Thread.Sleep(2000);

            IWebElement dateofbithyear = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            SelectElement selectyear = new SelectElement(dateofbithyear);
            selectyear.SelectByText("1990");
            Thread.Sleep(2000);

            IWebElement dateofbithDay = driver.FindElement(
                By.XPath("//div[@class='react-datepicker__day react-datepicker__day--020']"));
           dateofbithDay.Click();
            Thread.Sleep(2000);

            IWebElement subjectField = driver.FindElement(By.Id("subjectsInput"));
            subjectField.SendKeys("Maths");
            subjectField.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            subjectField.SendKeys("che");
            subjectField.SendKeys(Keys.Enter);
            Thread.Sleep(3000);


            IWebElement hobbiesradioButton = driver.FindElement(By.XPath("//label[text()='Sports']"));
            hobbiesradioButton.Click();
            Thread.Sleep(3000);

            IWebElement chooseFile = driver.FindElement(By.Id("uploadPicture"));
            chooseFile.SendKeys(@"C:\Users\Administrator\Documents\My Web Sites\WebSite1\bkg-blu.jpg");
            Thread.Sleep(3000);

            



        }
    }
}
