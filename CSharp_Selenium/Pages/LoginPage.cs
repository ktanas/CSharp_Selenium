using CSharp_Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement LoginLink => driver.FindElement(By.Id("loginlink"));
        IWebElement TxtUserName => driver.FindElement(By.Id("UserName"));
        IWebElement TxtPassword => driver.FindElement(By.Id("Password"));
        IWebElement BtnLogin => driver.FindElement(By.CssSelector(".btn"));
        IWebElement LinkEmployeeDetails => driver.FindElement(By.LinkText("Employee Details"));
        IWebElement LinkManageUsers => driver.FindElement(By.LinkText("Manage Users"));
        IWebElement LinkLogoff => driver.FindElement(By.LinkText("Log off"));
        /*
        public void ClickLogin()
        {
            SeleniumCustomMethods.ClickElement(LoginLink);
        }
        */

        public void ClickLogin()
        {
            LoginLink.Click();
        }

        public void Login(string username, string password)
        {
            /*
            TxtUserName.Clear();
            TxtUserName.SendKeys(username);
            */

            TxtUserName.EnterText(username);
            TxtPassword.EnterText(password);
            BtnLogin.SubmitElement();

            /*
            SeleniumCustomMethods.EnterText(TxtUserName, username);
            SeleniumCustomMethods.EnterText(TxtPassword, password);
            TxtUserName.SendKeys(username);

            TxtPassword.SendKeys(password);
            SeleniumCustomMethods.Submit(BtnLogin);
            BtnLogin.Submit();
            */
        }

        /*
        public bool IsLoggedIn()
        {
            return LinkEmployeeDetails.Displayed;
        }
        */
        /*
        public (bool, bool) IsLoggedIn()
        {
            return (LinkEmployeeDetails.Displayed, LinkManageUsers.Displayed);
        }
        */

        public (bool employeeDetails, bool manageUsers) IsLoggedIn()
        {
            return (LinkEmployeeDetails.Displayed, LinkManageUsers.Displayed);
        }
    }
}

