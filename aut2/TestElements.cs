using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using NUnit.Framework;

namespace aut2
{
    public class TestElements
    {
        private ConfigClass driver;

        #region
        IWebElement TextDisplayed;
        IWebElement FirstNameTextBox;
        IWebElement LastNameTextBox;
        IWebElement MobileTextBox;
        IWebElement Pass;
        IWebElement Month;
        IWebElement Day;
        IWebElement Year;
        IWebElement FemaleCheckBox;
        IWebElement TitleText; 
        #endregion

        public TestElements(string Browser)
        {
            driver = new ConfigClass(Browser);
        }

        public void Fill(string name)
        {
            FirstNameTextBox = driver.DriverD.FindElement(By.Name("firstname"));
            driver.WaitForElementClickable(FirstNameTextBox);
            FirstNameTextBox.SendKeys(name);
            Console.WriteLine("** Firstname Filled **");
        }
        public void FillLastName(string lastname)
        {

            LastNameTextBox = driver.DriverD.FindElement(By.Name("lastname"));
            driver.WaitForElementClickable(LastNameTextBox);
            LastNameTextBox.SendKeys(lastname);
            Console.WriteLine("** Lastname Filled **");
        }
        public void Fill(int mobile)
        {
            MobileTextBox = driver.DriverD.FindElement(By.Name("reg_email__"));
            driver.WaitForElementClickable(MobileTextBox);
            MobileTextBox.SendKeys(mobile.ToString());
            Console.WriteLine("** Mobile Filled **");
        }
        public void FillPass(string Password)
        {
            Pass = driver.DriverD.FindElement(By.Name("reg_passwd__"));
            driver.WaitForElementClickable(Pass);
            Pass.SendKeys(Password);
            Console.WriteLine("** Password Filled **");
        }
        public void SelectMonth()
        {
            Month = driver.DriverD.FindElement(By.Id("month"));
            driver.WaitForElementClickable(Pass);
            SelectDate(Month, 10);
            Console.WriteLine("** Month Selected **");
        }
        public void SelectDay()
        {
            Day = driver.DriverD.FindElement(By.Id("day"));
            driver.WaitForElementClickable(Day);
            SelectDate(Day, 15);
            Console.WriteLine("** Day Selected **");
        }
        public void SelectYear()
        {
            Year = driver.DriverD.FindElement(By.Id("year"));
            driver.WaitForElementClickable(Year);

            SelectDate(Year,25);
            Console.WriteLine("** Year Selected **"); 
        }
        public void SelectDate(IWebElement elem, int value)
        {
            switch (elem.ToString())
            {
                case "Year":
                    elem = driver.DriverD.FindElement(By.Id("year"));
                    driver.WaitForElementClickable(elem);
                    break;
                case "Month":
                    elem = driver.DriverD.FindElement(By.Id("month"));
                    driver.WaitForElementClickable(elem);
                    break;
                case "Day":
                    elem = driver.DriverD.FindElement(By.Id("day"));
                    driver.WaitForElementClickable(elem);
                    break;
            }
            var SelectElement = new SelectElement(elem);
            SelectElement.SelectByIndex(value);

        }
        public void CheckFemale()
        {
            FemaleCheckBox = driver.DriverD.FindElement(By.Id("u_0_9"));
            driver.WaitForElementClickable(FemaleCheckBox);
            MyClick(FemaleCheckBox);
            Console.WriteLine("** Checked Female Checkbox **");

        }
        public void MyClick(IWebElement element)
        {
            element.Click();
            Console.WriteLine("** Click performed **");
        }

        public void VerifyText()
        {
            TextDisplayed = driver.DriverD.FindElement(By.ClassName("_5iyx"));

            if (TextDisplayed.Displayed)
            {

                Console.WriteLine("** The expected text is present **");
            }
            else
            {
                Console.WriteLine("** The expected text is NOT present **");
            }

        }
        public void VerifyTitle()
        {
            TitleText = driver.DriverD.FindElement(By.XPath("//span[contains(text(),\"cuenta\")]"));
            Assert.AreEqual((TitleText.Text), "Abre una cuenta");
            try
            {
                Assert.AreEqual((TitleText.Text), "Abre una cuenta");
                Console.WriteLine("** Assertion passed **");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void DriverTitle()
        {
            string title = driver.DriverD.Title;
            try
            {
                Assert.AreEqual("Facebook - Inicia sesión o regístrate", title);
                Console.WriteLine("** Title Matched **");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void CleanUp() => driver.DriverD.Quit();

    }
}
