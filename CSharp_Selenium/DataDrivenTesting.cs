using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using CSharp_Selenium.Pages;
using System.Text.Json;


namespace CSharp_Selenium
{
    public class DataDrivenTesting
    {
        private IWebDriver _driver;
        private readonly string _userName;
        private readonly string _password;

        public DataDrivenTesting(string userName, string password)
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

            //ReadJsonFile();
        }
        [TestAttribute]
        [Category("ddt")]
        //[TestCaseSource(typeof(Login))]
        //[TestCaseSource(nameof(Login))]
        [TestCaseSource(nameof(LoginJsonDataSource))]

        public void TestWithPOM(LoginModel loginModel)
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);

            //Act
            loginPage.ClickLogin();
            //loginPage.Login("admin", "password");
            loginPage.Login(loginModel.UserName, loginModel.Password);

            //Assert
            var getLoggedIn = loginPage.IsLoggedIn();
            //Assert.IsTrue(getLoggedIn.Item1);
            Assert.IsTrue(getLoggedIn.employeeDetails && getLoggedIn.manageUsers);

        }

        [TestAttribute]
        [Category("ddt")]
        //[TestCaseSource(typeof(Login))]
        //[TestCaseSource(nameof(Login))]
        //public void TestWithPOMWithJSONData(LoginModel loginModel)
        public void TestWithPOMWithJSONData()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString);

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

        public static IEnumerable<LoginModel> LoginJsonDataSource()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);

            foreach (var loginData in loginModel)
            {
                yield return loginData;
            }
        }

        private void ReadJsonFile()
        {
            //AppDomain.CurrentDomain.BaseDirectory
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);

            var loginModel = JsonSerializer.Deserialize<LoginModel>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Console.WriteLine("UserName {0} Password {1}", loginModel.UserName, loginModel.Password);
        }

        [TearDownAttribute]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }

    }
}
