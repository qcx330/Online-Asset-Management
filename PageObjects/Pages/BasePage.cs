using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.core;
using AssetManagement.Core.Driver;
using OpenQA.Selenium;

namespace AssetManagement.PageObjects.Pages
{
    public class BasePage
    {
        IWebDriver webDriver;

        //Notification message
        private Element _notiToast(string txt) => new(By.XPath($"//div[@role='alert' and contains(.,'{txt}')]"));

        //Header
        private Element _btnDropDown = new(By.Id("dropdown-button"));
        private Element _optDropdown(string txt) => new(By.XPath($"//li[.='{txt}']"));
        private Element _btnConfirmLogout = new(By.XPath("//button[.='Log out']"));

        //Sidemenu
        protected Element _liSideMenu(string link) => new(By.XPath($"//span[.='{link}']"));

        protected BasePage()
        {
            webDriver = DriverManager.WebDriver;
        }
        public string GoToUrl(string url)
        {
            return webDriver.Url = url;
        }
        public bool IsNotiDisplayed(string txt){
            return _notiToast(txt).IsDisplayed();
        }
        public void VerifyNotificationDisplayed(string txt)
        {
            Assert.That(_notiToast(txt).IsDisplayed, Is.True, "Notification message is not displayed");
        }
        public bool IsToastNotificationInvisible(string txt)
        {
            return _notiToast(txt).WaitForElementTobeInvisible();
        }
        public void Logout()
        {
            if (IsToastNotificationInvisible("Login Successfully"))
            {
                _btnDropDown.ClickOnElement();
                _optDropdown("Logout").ClickOnElement();
                _btnConfirmLogout.ClickOnElement();
            }
        }
        public void OpenChangePasswordPopup(){
            if (IsToastNotificationInvisible("Login Successfully"))
            {
                _btnDropDown.ClickOnElement();
                _optDropdown("Change Password").ClickOnElement();
            }
        }
        public void NavigateSubmenuLink(string item)
        {
            _liSideMenu($"{item}").ClickOnElement();
        }
    }
}