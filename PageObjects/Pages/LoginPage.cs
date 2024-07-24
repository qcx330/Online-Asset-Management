using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.core;
using AssetManagement.Model;
using OpenQA.Selenium;

namespace AssetManagement.PageObjects.Pages
{
    public class LoginPage : BasePage
    {
        private Element _txtUsername = new(By.Id("username"));
        private Element _txtPassword = new(By.Id("password"));
        private Element _btnLogin = new(By.XPath("//button[.='Login']"));
        
        public void Login(AccountDto account){
            _txtUsername.InputText(account.Username);
            _txtPassword.InputText(account.Password);
            _btnLogin.ClickOnElement();
        }
        public void VerifyLoginButtonDisabled(){
            Assert.That(_btnLogin.IsEnabled, Is.False,"Login button still displays when leave username and password empty");
        }
        public bool SideMenuIsDisplayed(){
            return  _liSideMenu("Manage User").IsDisplayed() &&
                    _liSideMenu("Manage Asset").IsDisplayed() &&
                    _liSideMenu("Manage Assignment").IsDisplayed() &&
                    _liSideMenu("Request for Returning").IsDisplayed() &&
                    _liSideMenu("Report").IsDisplayed();
        }
        public void VerifyAdminUserLoginSuccessfully(){
            Assert.That(SideMenuIsDisplayed(), Is.True, "Side menu does not show");
        }
        public void VerifyStaffUserLoginSuccessfully(){
            Assert.That(SideMenuIsDisplayed(), Is.False, "Side menu shows");
        }
    }
}