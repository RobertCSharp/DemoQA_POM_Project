using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Drawing;

namespace DemoQA_POM_Project
{
    public class BaseTest
    {
        IWebDriver driver;
        HomePage homePage;


        [SetUp]
        public void Setup()
        {
            this.driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/books");
            this.homePage = new HomePage(driver);

        }

        [Test]
        public void GoToWebSiteTest()
        {
        }

        [Test]
        public void CheckIfTitleLogoDisplayed()
        {
            Assert.True(homePage.CheckLogo());
        }

        [Test]
        public void CheckIfLoginButtonDisplayedBlue()
        {
            string blueColor = "rgb(0, 123, 255)";

            Assert.That(blueColor, Is.EqualTo(homePage.GetLoginColor()));
        }

        [Test]
        public void CheckIfWriteSameTitleAndColor()
        {
            string grayColor = "rgb(170, 170, 170)";

            Assert.True(homePage.CheckTitle());
            Assert.That(grayColor, Is.EqualTo(homePage.GetTitleColor()));
        }

        [Test]
        public void CheckColorElement()
        {
            string whiteColor = "rgb(255, 255, 255)";

            Assert.That(whiteColor, Is.EqualTo(homePage.CheckIfColorIsSame()));

            string grayColor = "rgb(108, 117, 125)";

            Assert.That(grayColor, Is.EqualTo(homePage.CheckBackGroundColorElement()));
        }

        [Test]
        public void CheckNumberOfRows()
        {
            homePage.ScrollToElement();
            homePage.VerifyNumberOFRows();
        }
    } 
}