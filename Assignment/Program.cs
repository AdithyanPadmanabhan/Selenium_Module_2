using Assignment;
using NUnit.Framework;

//Assignment -1 14-11-2023

//AmazonHomePage amazonHomePage = new AmazonHomePage();  //creating object for amazon home page class

//try
//{
//    amazonHomePage.InitializeChromeDriver(); // calling intialize method
//    amazonHomePage.TitleTest();              // calling title test method
//    amazonHomePage.OrganisationTypeTest();   // calling  organisationType test
//}

//catch (AssertionException)
//{
//    Console.WriteLine(" Title Test failed");  if test failed it will display as "Test failed"
//}
//amazonHomePage.Destruct(); // calling destruct method


//Assignment-2 14-11-2023

LaunchNewBrowser launchNewBrowser = new LaunchNewBrowser();
try
{
    launchNewBrowser.InitializeChromeDriver(); //calling intialize method
    launchNewBrowser.SearchResultTest(); // calling SearchResulTest  method
                                     
}
catch (AssertionException)
{
    Console.WriteLine(" Title Test failed");
}
    launchNewBrowser.Destruct();