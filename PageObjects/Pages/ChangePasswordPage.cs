using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Constant;
using AssetManagement.core;
using OpenQA.Selenium;

namespace AssetManagement.PageObjects.Pages
{
    public class ChangePasswordPage:BasePage
    {
        private Element _txtField(string id) => new(By.Id(id));
        private Element _btnPopup(string txt) => new(By.XPath($"//button[.='{txt}']"));
        private Element _lblSuccess = new(By.XPath($"//p[.='{MessageConstant.ChangePasswordSuccessfully}']"));
        public void ChangePassword(string oldPassword, string newPassword){
            _txtField("oldPassword").InputText(oldPassword);
            _txtField("newPassword").InputText(newPassword);
            _btnPopup("Save").ClickOnElement();
        }
        public void VerifyChangePassword(){
            Assert.That(_lblSuccess.IsDisplayed, Is.True, "Label is not displayed");
        }
        public void RechangePassword(string oldPassword, string newPassword){
            _btnPopup("Close").ClickOnElement();
            OpenChangePasswordPopup();
            ChangePassword(oldPassword, newPassword);
            _lblSuccess.WaitForElementToBeVisible();
        }
    }    
}