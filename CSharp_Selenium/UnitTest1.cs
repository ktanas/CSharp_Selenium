using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using CSharp_Selenium.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace CSharp_Selenium
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();

            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.FindElement(By.Id("W0wltc")).Click();
            //IWebElement el1 = driver.FindElement(By.LinkText("Odrzuæ wszystko"));
            //el1.Click();
            //driver.FindElement(By.LinkText("Odrzuæ wszystko")).Click();

            IWebElement webElement = driver.FindElement(By.Name("q"));
            webElement.SendKeys("Selenium");
            webElement.SendKeys(Keys.Return);
            webElement.Click();

        }
        [Test]
        public void TestWithPOM()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://eaapp.somee.com");

            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickLogin();
            loginPage.Login("admin", "password");

        }

        [Test]
        public void EAWebSiteTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            //IWebElement loginLink = driver.FindElement(By.LinkText("Login"));
            //IWebElement loginLink = driver.FindElement(By.Id("loginLink"));
            //loginLink.Click();
            SeleniumCustomMethods.Click(driver, By.Id("loginLink"));
            SeleniumCustomMethods.EnterText(driver, By.Name("UserName"), "admin");
            SeleniumCustomMethods.EnterText(driver, By.Name("Password"), "password");

            driver.FindElement(By.CssSelector(".btn")).Submit();

            //Explicit wait
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
                Message = "Textbox UserName does not appear during that timeframe"
            };

            driverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            var txtUserName = driverWait.Until(d =>
            {
                var element = driver.FindElement(By.Name("UserNames"));
                return (element != null && element.Displayed) ? element : null;
            });

            /*
            IWebElement txtUserName = driver.FindElement(By.Name("UserName"));
            txtUserName.SendKeys("admin");
            IWebElement txtPassword = driver.FindElement(By.Id("Password"));
            txtPassword.SendKeys("password");
            //IWebElement btnLogin = driver.FindElement(By.ClassName(".btn"));
            IWebElement btnLogin = driver.FindElement(By.CssSelector(".btn"));
            btnLogin.Submit();
            */
        }

        [Test]
        public void WorkingWithAdvancedControls()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("file://C:/testpage.html");

            driver.FindElement(By.Id("loginLink")).Click();

            //SelectElement selectElement = new SelectElement(driver.FindElement(By.Id("dropdown"));
            //selectElement.SelectByText("Option 2");
            SeleniumCustomMethods.SelectDropdownByText(driver, By.Id("dropdown"), "Option 2");

            //SelectElement multiSelect = new SelectElement(driver.FindElement(By.Id("multiSelect")));
            //multiSelect.SelectByValue("multi1");
            //multiSelect.SelectByValue("multi2");
            SeleniumCustomMethods.MultiSelectElements(driver, By.Id("multiselect"), ["multi1", "multi2"]);

            var getSelectedOptions = SeleniumCustomMethods.GetAllSelectedLists(driver, By.Id("multiselect"));

            getSelectedOptions.ForEach(Console.WriteLine);
            /*
            foreach (var selectedOption in getSelectedOptions)
            {
                Console.WriteLine(selectedOption);
            }
            */


            /*
            IList<IWebElement> selectedOption = multiSelect.AllSelectedOptions;
            foreach(IWebElement option in selectedOption)
            {
                Console.WriteLine(option.Text);
            }
            */

            IWebElement loginLink = driver.FindElement(By.Id("loginLink"));
            loginLink.Click();

            SeleniumCustomMethods.Click(driver, By.Id("loginLink"));
            // custom method, defined in my own SeleniumCustomMethods.cs file

        }
    }
}