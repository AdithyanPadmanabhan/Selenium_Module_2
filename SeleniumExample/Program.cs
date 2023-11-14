using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExample;

GHPTests ghpTests = new GHPTests();
//Console.WriteLine("Choose: 1: Edge 2: Chrome");
//int ch = Convert.ToInt32(Console.ReadLine());
//switch (ch)
//{
//    case 1:

//        ghpTests.InitializeEdgeDriver();
//        break;
//    case 2:

//        ghpTests.InitializeChromeDriver();
//        break;


//}

List<string> drivers = new List<string>();
drivers.Add("Chrome");
drivers.Add("Edge");

foreach (var d in drivers)
{
    switch (d)
    {
       
        case "Chrome":

            ghpTests.InitializeChromeDriver();
            break;
        case "Edge":

            ghpTests.InitializeEdgeDriver();
            break;
    }


            try
    {
        //ghpTests.TitleTest();
        //ghpTests.PageSourceAndURLTest();
        //ghpTests.GoogleSearchTest();
        //ghpTests.GmailLinkTest();
        //ghpTests.ImagesLinkTest();
        //ghpTests.LocalizationTest();
        ghpTests.GoogleAppYoutubeTest();

    }
    catch (AssertionException)
    {
        Console.WriteLine(" Title Test failed");
    }
    ghpTests.Destruct();

}