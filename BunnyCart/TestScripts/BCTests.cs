using BunnyCart.PageObjects;
using BunnyCart.Utilities;
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

           // bchp.SignUp("Adhi", "Padman", "adhi@gmail.com", "123456", "123456", "8921287202");



            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccount";

            List<SignUp> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;
                string? pwd = excelData?.Password;
                string? conpwd = excelData?.ConfirmPassword;
                string? mbno = excelData?.MobileNumber;

                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");


                bchp.SignUp(firstName, lastName, email, pwd, conpwd, mbno);
                // Assert.That(""."")

            }
        }

       
    }
}
