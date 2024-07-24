using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.core;
using AssetManagement.Model;
using FluentAssertions;
using OpenQA.Selenium;

namespace AssetManagement.PageObjects.Pages.ManageAssignment
{
    public class EditAssignmentPage : ManageAssignmentPage
    {
        private Element _txtField(string field) => new(By.Id($"{field}"));
        Element _btnSave = new(By.XPath("//button[.='Save']"));
        Element _btnSavePopup(string field) => new(By.Id($"{field}"));
        Element _rowSecondOfTable = new(By.CssSelector("tbody tr:nth-child(2) td:nth-child(3)"));
        public void EditAssignment(AssignmentDto assignment)
        {
            string staffName = SelectUser();
            assignment.User = staffName;
            string assetname = SelectAsset();
            assignment.Asset = assetname;
            string assignedDate = InputDate();
            assignment.AssignDate = assignedDate;
            InputNote(assignment.Note);
            _btnSave.ClickOnElement();
        }
        public string SelectUser()
        {
            _txtField("staffCode").ClickOnElement();
            string staffName = _rowSecondOfTable.GetTextFromElement();
            _rowSecondOfTable.ClickOnElement();
            _btnSavePopup("saveAccount").ClickOnElement();
            return staffName;
        }
        public string SelectAsset()
        {
            _txtField("assetCode").ClickOnElement();
            string assetname = _rowSecondOfTable.GetTextFromElement();
            _rowSecondOfTable.ClickOnElement();
            _btnSavePopup("saveAsset").ClickOnElement();
            return assetname;
        }
        public string InputDate()
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("MMddyyyy");
            _txtField("assignedDate").InputText(formattedDate);
            return formattedDate;
        }
        public void InputNote(string note)
        {
            if (string.IsNullOrEmpty(note))
            {
                return;
            }
            _txtField("note").InputText(note);
        }

    }
}