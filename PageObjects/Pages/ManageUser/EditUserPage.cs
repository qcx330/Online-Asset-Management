using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.core;
using AssetManagement.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;

namespace AssetManagement.PageObjects.Pages
{
    public class EditUserPage:ManageUserPage
    {
        private Element _txtField(string field) => new(By.Id($"{field}"));
        private Element _ddlType = new(By.Id("type"));
        private Element _ddlLocation = new(By.Name("location"));
        private Element _chkGender(string gender) => new(By.CssSelector($"input[value='{gender}']"));
        private Element _btnSave = new(By.XPath("//button[.='Save']"));
        public void EditUser(UserDto user){
            EnterDoB(user.DateOfBirth);
            SelectGender(user.Gender);
            EnterJoinDate(user.JoinedDate);
            SelectType(user.Type);
            SelectLocation(null);
            ClickOnSaveButton();
        }
        public void ClickOnSaveButton(){
            _btnSave.ClickOnElement();
        }
        public void EnterDoB(string dob){
            if (string.IsNullOrEmpty(dob))
                return;
            _txtField("dob").ClearText();
            _txtField("dob").InputText(dob);
        }
        public void SelectGender(string gender){
            if (string.IsNullOrEmpty(gender.ToLower()))
                return;
            _chkGender(gender.ToLower()).ClickOnElement();
        }
        public void EnterJoinDate(string joinDate){
            if (string.IsNullOrEmpty(joinDate))
                return;
            _txtField("joinDate").ClearText();
            _txtField("joinDate").InputText(joinDate);
        }
        public void SelectType(string type){
            if (string.IsNullOrEmpty(type))
                return;
            _ddlType.SelectByText(type);
        }
        public void SelectLocation(string location){
            if (string.IsNullOrEmpty(location))
                return;
            _ddlLocation.SelectByText(location);
        }
    }
}