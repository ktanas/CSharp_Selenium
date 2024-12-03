using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Selenium
{
    public static class SeleniumCustomMethods
    {

        public static void Click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }


        /*
        public static void Click(IWebElement locator)
        {
            locator.Click();
        }
        */

        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }


        public static void Submit(IWebElement locator)
        {
            locator.Submit();
        }


        public static void SubmitElement(this IWebElement locator)
        {
            locator.Submit();
        }

        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }


        public static void SelectDropdownByText(IWebDriver driver, By locator, string text)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByText(text);
        }

        public static void SelectDropdownByText(this IWebElement locator, string text)
        {
            SelectElement selectElement = new SelectElement(locator);
            selectElement.SelectByText(text);
        }

        public static void SelectDropdownByValue(this IWebDriver driver, By locator, string value)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByValue(value);
        }

        public static void SelectDropdownByIndex(this IWebDriver driver, By locator, int index)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByIndex(index);
        }


        public static void MultiSelectElements(IWebDriver driver, By locator, string[] values)
        {
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));
            foreach (var x in values)
            {
                multiSelect.SelectByValue(x);
            }
        }


        public static void MultiSelectElements(this IWebElement locator, string[] values)
        {
            SelectElement multiSelect = new SelectElement(locator);
            foreach (var x in values)
            {
                multiSelect.SelectByValue(x);
            }
        }

        public static List<string> GetAllSelectedLists(IWebDriver driver, By locator)
        {
            List<string> options = new List<string>();
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));

            IList<IWebElement> selectedOptions = multiSelect.AllSelectedOptions;
            foreach (IWebElement option in selectedOptions)
            {
                options.Add(option.Text);
            }
            return options;
        }

        public static List<string> GetAllSelectedLists(this IWebElement locator)
        {
            List<string> options = new List<string>();
            SelectElement multiSelect = new SelectElement(locator);

            IList<IWebElement> selectedOptions = multiSelect.AllSelectedOptions;
            foreach (IWebElement option in selectedOptions)
            {
                options.Add(option.Text);
            }
            return options;
        }

    }
}
