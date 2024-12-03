using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium
{
    public class SeleniumTestsWithWaitRetry
    {
        /*
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
        }

        [Test]
        public void TestWithWaitAndRetry()
        {
            var loginLink = _driver.FindElement(By.Id("loginLink"));
            loginLink.Click();

            var retryPolicy = RetryPolicy();
            var txtUserName = retryPolicy.Execute(() => _driver.FindElement(By.Name("UserNames")));
            txtUserName.SendKeys("admin");

            var txtPassword = _driver.FindElement(By.Id("Password"));
            txtPassword.SendKeys("password");
            var btnLogin = _driver.FindElement(By.CssSelector(".btn"));
            btnLogin.Submit();

        */


        //Explicit wait
        /*
        WebDriverWait driverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
        {
            PollingInterval = TimeSpan.FromMilliseconds(200),
            Message = "Textbox UserName does not appear during that timeframe"
        };

        driverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

        var txtUserName = driverWait.Until(d =>
        {
            var element = _driver.FindElement(By.Name("UserNames"));
            return (element != null && element.Displayed) ? element : null;
        });
        */


        //Retry mechanism using the 'Polly' package
        /*
        var retryPolicy = Policy.Handle<NoSuchElementException>()
                          .Or<StaleElementReferenceException>()
                          .WaitAndRetry(retryCount: 4,
                          sleepDurationProvider: retryProvider => TimeSpan.FromSeconds(3),
                          onRetry: (exception, timeSpan, retryCount, context) =>
                          {
                              Console.WriteLine("Retrying ... (Attempt " + retryCount + ") with Exception " + exception.Message);
                          });
        */

        /*
        retryPolicy.Execute(() =>
        {
            return _driver.FindElement(By.Name("UserNames"));
        });
        */
        /*
        retryPolicy.Execute(() => _driver.FindElement(By.Name("UserNames")));


        var txtUserName = _driver.FindElement(By.Name("UserNames"));
        txtUserName.SendKeys("admin");

        var txtPassword = _driver.FindElement(By.Id("Password"));
        txtPassword.SendKeys("password");
        var btnLogin = _driver.FindElement(By.CssSelector(".btn"));
        btnLogin.Submit();
        */
    }

    /*
        private static RetryPolicy RetryPolicy()
        {
            var retryPolicy = Policy
                .Handle<NoSuchElementException>()
                .Or<StaleElementReferenceException>()
                .WaitAndRetry(retryCount: 4,
                    sleepDurationProvider: retryProvider => TimeSpan.FromSeconds(3),
                    onRetry: (exception, timeSpan, retryCount, context) =>
                    {
                        Console.WriteLine("Retrying ... (Attempt {0} with exception {1}",
                            retryCount, exception.Message);
                    });
            return retryPolicy;
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
    */
}

