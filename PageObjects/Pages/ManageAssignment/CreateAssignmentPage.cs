using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.core;
using AssetManagement.Core.Driver;
using AssetManagement.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Razor.Language;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using DriverManager = AssetManagement.Core.Driver.DriverManager;

namespace AssetManagement.PageObjects.Pages.ManageAssignment
{
    public class CreateAssignmentPage : ManageAssignmentPage
    {
        Element _rowFirstOfTable = new(By.CssSelector("tbody tr:first-child"));
        Element _rowFirstByStaffName(string name, int index) => new(By.XPath($"//tbody/tr[contains(text(), {name})][1]/td[{index}]"));
        Element _btnSavePopup(string field) => new(By.Id($"{field}"));
        Element _btnSave = new(By.XPath("//button[.='Save']"));
        private Element _txtField(string field) => new(By.Id($"{field}"));

        public void CreateAssignment(AssignmentDto assignment)
        {
            string name = SelectUser(assignment.User);
            assignment.User = name;
            string assetname = SelectAsset();
            assignment.Asset = assetname;
            InputDate(assignment.AssignDate);
            InputNote(assignment.Note);
            _btnSave.ClickOnElement();
        }
        public string SelectUser(string user)
        {
            _txtField("staffCode").ClickOnElement();
            _txtField("search-user").InputText(user);
            _txtField("search-user").PressEnter();
            string name = _rowFirstByStaffName(user, GetFullNameColumn()).GetTextFromElement();
            _rowFirstByStaffName(user, GetFullNameColumn()).ClickOnElement();
            _btnSavePopup("saveAccount").ClickOnElement();
            return name;
        }
        public string SelectAsset()
        {
            _txtField("assetCode").ClickOnElement();
            string assetname = _rowFirstOfTable.GetTextFromElement();
            _rowFirstOfTable.ClickOnElement();
            _btnSavePopup("saveAsset").ClickOnElement();
            return assetname;
        }
        public void InputDate(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return;
            }
            _txtField("assignedDate").InputText(date);
        }
        public void InputNote(string note)
        {
            if (string.IsNullOrEmpty(note))
            {
                return;
            }
            _txtField("note").InputText(note);
        }
        public int GetFullNameColumn()
        {
            List<string> columnNames = new List<string>();
            IList<IWebElement> columnElemList = DriverManager.WebDriver.FindElements(By.CssSelector("thead tr th"));
            foreach (var item in columnElemList)
            {
                columnNames.Add(item.Text.Trim());
            }
            return columnNames.IndexOf("Full Name") + 1;
        }

    }

}