using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;

namespace DemoQA_POM_Project
{
    public class HomePage
    {
         IWebDriver driver;

         public HomePage(IWebDriver driver)
         {
             this.driver = driver;
         }

         private IWebElement Logo => driver.FindElement(By.XPath("//img[@src='/images/Toolsqa.jpg']"));

         public bool CheckLogo()
         {
             return Logo.Displayed;
         }

         private IWebElement LoginButton => driver.FindElement(By.CssSelector("#login"));

         public string GetLoginColor()
         {
             return LoginButton.GetCssValue("background-color");
         }

         private IWebElement Title => driver.FindElement(By.CssSelector(".main-header"));
         

         public bool CheckTitle()
         {
             return Title.Displayed;
         }

         public string GetTitleColor()
         {
             return Title.GetCssValue("Color");
         }

         private IWebElement ColorElement => driver.FindElement(By.XPath("(//div[@class='header-text'])[1]"));

         public string CheckIfColorIsSame()
         {
             return ColorElement.GetCssValue("color");
         }

         private IWebElement BackGroundColor => driver.FindElement(By.XPath("(//div[@class='header-wrapper'])[1]"));

         public string CheckBackGroundColorElement()
         {
             return BackGroundColor.GetCssValue("background");
         }

         public void ScrollToElement()
         {
            var elem = driver.FindElement(By.XPath("//select[@aria-label='rows per page']"));
            driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", elem);
           
         }

         public void VerifyNumberOFRows()
         {
             string numberRows = "10 rows";

             Assert.AreEqual(driver.FindElement(By.XPath("//option[@value='10']")).Text, numberRows);
        }
    }
}
