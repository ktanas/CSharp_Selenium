using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSharp_Selenium.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium
{
    [TestFixture("admin", "password")]
    public class NUnitTestsDemo
    {
        private IWebDriver _driver;
        private readonly string _userName;
        private readonly string _password;

        public NUnitTestsDemo(string userName, string password)
        {
            this._userName = userName;
            this._password = password;
        }

        [SetUpAttribute]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com");
            _driver.Manage().Window.Maximize();
        }

        [TestAttribute]
        [Category("ddt")]
        //[TestCaseSource(typeof(Login))]
        [TestCaseSource(nameof(Login))]
        public void TestWithPOM(LoginModel loginModel)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickLogin();
            //loginPage.Login("admin", "password");
            loginPage.Login(loginModel.UserName, loginModel.Password);
        }

        public static IEnumerable<LoginModel> Login()
        {
            yield return new LoginModel()
            {
                UserName = "admin",
                Password = "password"
            };
            yield return new LoginModel()
            {
                UserName = "admin2",
                Password = "password"
            };
            yield return new LoginModel()
            {
                UserName = "admin3",
                Password = "password"
            };
        }

        [TestAttribute]
        [TestCase("chrome", "30")]

        public void TestBrowserVersion(string browser, string version)
        {
            Console.WriteLine(browser);
        }

        [TearDownAttribute]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}

