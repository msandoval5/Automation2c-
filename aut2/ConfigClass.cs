using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;

namespace aut2
{
    public class ConfigClass
    {
        
        public IWebDriver driver;
        public IWebDriver DriverD => driver;

        public string Title { get; internal set; }

        public ConfigClass()
        {

        }

        public ConfigClass(string Browser)
        {

            switch (Browser)
                {
                    case "Chrome":
                    default:
                        driver = new ChromeDriver(@"/Users/mariana.sandoval/Projects/aut2/aut2/bin/Debug");
                        driver.Manage().Window.Maximize();
                        break;

                    case "FireFox":
                        driver = new FirefoxDriver(@"/Users/mariana.sandoval/Projects/aut1/aut1/bin");
                        driver.Manage().Window.Maximize();
                        break;
                }
                Console.WriteLine("** Browser Selected **");
            GoTo();

                return;
        }
        public void GoTo()
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            Console.WriteLine("** Browser GoTo executed **");
        }
        public void WaitForElementClickable(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));

        }
        /* public void WaitForElement(string identifier, string locator)
          {
              WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              IWebElement element = null;
              switch (locator)
              {
                  case "id":
                      element = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(identifier)));
                      break;
                  case "name":
                      element = wait.Until(ExpectedConditions.ElementIsVisible(By.Name(identifier)));
                      break;
                  case "class":
                      element = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(identifier)));
                      break;
                  default:
                      break;
              }

          } */

        public void CleanUp() => driver.Quit();
    }
}

/* Create the following flow.

Go to facebook.com.
Validate the Title of the page, should be : Facebook - Log In or Sign Up.
Fill all Sign Up section.
Choose a different Birthday not the default one.
Click on Female.
Validate following text is present:
Connect with friends and the
world around you on Facebook.
B. Implement explicit waits for all the elements.

C. Separate the console app project in two, set up class and execution class.

D. Use A property to obtain Web title and assert to validate it.
*/