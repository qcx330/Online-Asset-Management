using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AssetManagement.Core.Extensions
{
    public static class DriverExtension
    {
        private static WebDriverWait GetWebDriverWait(this IWebDriver driver, TimeSpan timeout)
        {
            return new WebDriverWait(driver, timeout);
        }

        public static void NavigateTo(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElement(this IWebDriver driver, By locator)
        {
            return driver.FindElement(locator);
        }

        public static ICollection<IWebElement> FindElements(this IWebDriver driver, By locator)
        {
            return driver.FindElements(locator);
        }

        public static IWebElement WaitForElementToBeVisible(this IWebDriver driver, By locator, TimeSpan timeout = default)
        {
            timeout = timeout == default ? TimeSpan.FromSeconds(10) : timeout;
            return driver.GetWebDriverWait(timeout).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement WaitForElementToBeClickable(this IWebDriver driver, By locator, TimeSpan timeout = default)
        {
            timeout = timeout == default ? TimeSpan.FromSeconds(10) : timeout;
            return driver.GetWebDriverWait(timeout).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static bool IsElementLocated(this IWebDriver driver, By locator, TimeSpan timeout = default)
        {
            timeout = timeout == default ? TimeSpan.FromSeconds(10) : timeout;
            return driver.GetWebDriverWait(timeout).Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void WaitForUrlToContain(this IWebDriver driver, string url, TimeSpan timeout = default)
        {
            timeout = timeout == default ? TimeSpan.FromSeconds(10) : timeout;
            driver.GetWebDriverWait(timeout).Until(ExpectedConditions.UrlContains(url));
        }

        public static void HandleAlert(this IWebDriver driver, Action<IAlert> action, TimeSpan timeout = default)
        {
            timeout = timeout == default ? TimeSpan.FromSeconds(10) : timeout;
            driver.GetWebDriverWait(timeout).Until(ExpectedConditions.AlertIsPresent());
            var alert = driver.SwitchTo().Alert();
            action(alert);
        }

        public static void AcceptAlert(this IWebDriver driver, TimeSpan timeout = default)
        {
            driver.HandleAlert(alert => alert.Accept(), timeout);
        }

        public static void DismissAlert(this IWebDriver driver, TimeSpan timeout = default)
        {
            driver.HandleAlert(alert => alert.Dismiss(), timeout);
        }

        public static string GetAlertText(this IWebDriver driver, TimeSpan timeout = default)
        {
            timeout = timeout == default ? TimeSpan.FromSeconds(10) : timeout;
            driver.GetWebDriverWait(timeout).Until(ExpectedConditions.AlertIsPresent());
            return driver.SwitchTo().Alert().Text;
        }

        public static bool IsPageSourceContains(this IWebDriver driver, string text)
        {
            return driver.PageSource.Contains(text);
        }
    }
}