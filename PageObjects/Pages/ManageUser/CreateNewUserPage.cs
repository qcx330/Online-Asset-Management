using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.core;
using AssetManagement.Model;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V123.Browser;

namespace AssetManagement.PageObjects.Pages
{
    public class CreateNewUserPage:ManageUserPage
    {
        private Element _txtField(string field) => new(By.Id($"{field}"));
        private Element _ddlType = new(By.Id("type"));
        private Element _chkGender(string gender) => new(By.CssSelector($"input[value='{gender}']"));
        private Element _btnSave = new(By.XPath("//button[.='Save']"));
        public void CreateNewUser(UserDto user){
            EnterFirstName(user.FirstName);
            EnterLastName(user.LastName);
            EnterDoB(user.DateOfBirth);
            SelectGender(user.Gender);
            EnterJoinDate(user.JoinedDate);
            SelectType(user.Type);
            ClickOnSaveButton();
        }
        public void VerifySaveButtonIsDisabled(){
            Assert.That(_btnSave.IsEnabled(), Is.False, "Save button is enabled when leave field empty");
        }
        public void ClickOnSaveButton(){
            _btnSave.ClickOnElement();
        }
        public void EnterFirstName(string firstName){
            _txtField("firstName").InputText(firstName);
        }    
        public void EnterLastName(string lastName){
            _txtField("lastName").InputText(lastName);
        } 
        public void EnterDoB(string dob){
            _txtField("dob").InputText(dob);
        }
        public void SelectGender(string gender){
            _chkGender(gender.ToLower()).ClickOnElement();
        }
        public void EnterJoinDate(string joinDate){
            _txtField("joinDate").InputText(joinDate);
        }
        public void SelectType(string type){
            _ddlType.SelectByText(type);
        }
    }
}