using AventStack.ExtentReports.Model;
using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log = Serilog.Log;

namespace BunnyCart.TestScripts
{
    internal class BCTests : CoreCodes
    {
        //    [Test]
        //    public void SignUpTest()
        //    {
        //        string? currDir = Directory.GetParent(@"../../../")?.FullName;
        //        string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";

        //        Log.Logger = new LoggerConfiguration()
        //            .WriteTo.Console()
        //            .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();

        //        BCHPage bchp = new(driver);
        //        bchp.ClickCreateAccountLink();
        //        Thread.Sleep(3000);
        //        //try
        //        //{
        //        //    Assert.That(driver.FindElement(By.XPath("//h1[contains(text(),'Create an Account')]"))
        //        //        .Text, Is.EqualTo("Create an Account"));

        //        //}
        //        //catch (AssertionException)
        //        //{
        //        //    Console.WriteLine("Create Account modal is not present");
        //        //}

        //        try
        //        {
        //            //Assert.That(driver?.FindElement(By.XPath("//div[" +
        //            //    "@class='modal-inner-wrap']//following::h1[2]")).Text,
        //            //    Is.EqualTo("Create an Account"));
        //            Assert.IsTrue(driver?.FindElement(By.XPath("//div[" +
        //              "@class='modal-inner-wrap']//following::h1[2]")).Text == "Create an Account", $"Test failed for Create Account");
        //            Log.Information("Test passed for Create Account");
        //            test = extent.CreateTest("Create Account Link Test - Pass");
        //            test.Pass("Create Account Link success");
        //            Console.WriteLine("ERCP");
        //        }
        //        catch (AssertionException ex)
        //        {
        //            Log.Error($"Test failed for Create Account. /n Exception: {ex.Message}");
        //            test = extent.CreateTest("Create Account Link Test - Fail");
        //            test.Fail("Create Account Link failed");
        //        }
        //        //string? currDir = Directory.GetParent(@"../../../")?.FullName;


        //        // bchp.SignUp("Adhi", "Padman", "adhi@gmail.com", "123456", "123456", "8921287202");




        //        string? excelFilePath = currDir + "/TestData/InputData.xlsx";
        //        string? sheetName = "CreateAccount";

        //        List<SignUp> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

        //        foreach (var excelData in excelDataList)
        //        {

        //            string? firstName = excelData?.FirstName;
        //            string? lastName = excelData?.LastName;
        //            string? email = excelData?.Email;
        //            string? pwd = excelData?.Password;
        //            string? conpwd = excelData?.ConfirmPassword;
        //            string? mbno = excelData?.MobileNumber;

        //            Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");


        //            bchp.SignUp(firstName, lastName, email, pwd, conpwd, mbno);
        //            // Assert.That(""."")

        //        }

        //        Log.CloseAndFlush();
        //    }


        //}

        [Test]
        public void SignUpTest()
        {
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();

            BCHPage bchp = new(driver);
            bchp.ClickCreateAccountLink();
            Thread.Sleep(3000);
            //try
            //{
            //    Assert.That(driver.FindElement(By.XPath("//h1[contains(text(),'Create an Account')]"))
            //        .Text, Is.EqualTo("Create an Account"));

            //}
            //catch (AssertionException)
            //{
            //    Console.WriteLine("Create Account modal is not present");
            //}

            try
            {
                //Assert.That(driver?.FindElement(By.XPath("//div[" +
                //    "@class='modal-inner-wrap']//following::h1[2]")).Text,
                //    Is.EqualTo("Create an Account"));
                Assert.IsTrue(driver?.FindElement(By.XPath("//div[" +
                  "@class='modal-inner-wrap']//following::h1[2]")).Text == "Create an Account", $"Test failed for Create Account");
              //  Log.Information("Test passed for Create Account");
             LogTestResult("Create Account Link Test - Pass","Create Account Link success");
              
               
            }
            catch (AssertionException ex)
            {
              //  Log.Error($"Test failed for Create Account. /n Exception: {ex.Message}");
              LogTestResult("Create Account Link Test",
                "Create Account Link failed",ex.Message);
            }
            //string? currDir = Directory.GetParent(@"../../../")?.FullName;


            // bchp.SignUp("Adhi", "Padman", "adhi@gmail.com", "123456", "123456", "8921287202");




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
               

            }

            Log.CloseAndFlush();
        }


    }

}

