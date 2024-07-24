using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.core;
using AssetManagement.Core.Driver;
using AssetManagement.Model;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace AssetManagement.PageObjects.Pages
{
    public class ManageUserPage : BasePage
    {
        private Element _tblUser = new(By.TagName("table"));
        private Element _btnCreateUser = new(By.XPath("//a[.='Create new user']"));
        private Element _rowFirstOfTable = new(By.CssSelector("tbody tr:first-child"));
        private Element _btnEditFirstOfTable = new(By.CssSelector("tbody tr:first-child button:first-child"));
        private Element _btnDisabledFirstOfTable = new(By.CssSelector("tbody tr:first-child button:last-child"));
        private Element _txtSearchBox = new(By.CssSelector("input[type='text']"));
        private Element _lblNoAccount = new(By.XPath("//p[.='There is no account!']"));
        private Element _btnDisable = new(By.XPath("//button[.='Disable']"));
        public void ClickOnDisableUserButton()
        {
            _btnDisable.ClickOnElement();
        }
        public void ClickOnCreateUserButton()
        {
            _btnCreateUser.ClickOnElement();
        }
        public void ClickOnFirstRowOfTableUser()
        {
            _rowFirstOfTable.ClickOnElement();
        }
        public void WaitForTableDisplay()
        {
            _tblUser.WaitForElementToBeVisible();
        }
        public void ClickOnEditButtonOfFirstRowOfTableUser()
        {
            WaitForTableDisplay();
            _btnEditFirstOfTable.ClickOnElement();
        }
        public void ClickOnDisabledButtonOfFirstRowOfTable()
        {
            WaitForTableDisplay();
            _btnDisabledFirstOfTable.ClickOnElement();
        }
        public string RandomStaffCode()
        {
            Random random = new Random();
            int randomInt = random.Next(1, 201);
            string formattedInt = randomInt.ToString("D3");
            return "SD0" + formattedInt;
        }
        public void SearchByCriteria(string name)
        {
            _txtSearchBox.ClearText();
            _txtSearchBox.InputText(name);
            _txtSearchBox.PressEnter();
        }
        public void SearchForRandomStaffcode()
        {
            do
            {
                _txtSearchBox.ClearText();
                _txtSearchBox.InputText(RandomStaffCode());
                _txtSearchBox.PressEnter();
                if (_lblNoAccount.IsDisplayed() is false) break;
            } while (_lblNoAccount.IsDisplayed());
        }
        public void VerifyNoResultFound(){
            Assert.That(_lblNoAccount.IsDisplayed, Is.True);
        }
    }
}