using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.core;
using OpenQA.Selenium;

namespace AssetManagement.PageObjects.Pages.ManageAssignment
{
    public class ManageAssignmentPage:BasePage
    {
        private Element _tblAssignment = new(By.TagName("table"));
        private Element _btnCreateAssignment = new(By.XPath("//a[.='Create New Assignment']"));
        private Element _rowFirstOfTable = new(By.CssSelector("tbody tr:first-child"));
        private Element _txtSearchBox = new(By.Id("search-assignment"));
        private Element _btnRow(string button) => new(By.XPath($"(//tr[td//text()[contains(., 'Waiting For Acceptance')]]//button[@data-testid='{button}-button'])[1]"));
        private Element _btnDelete = new(By.XPath("//button[.='Delete']"));
        public void ClickOnCreateAssignmentButton()
        {
            _btnCreateAssignment.ClickOnElement();
        }
        public void ClickOnFirstRowOfTableUser()
        {
            _rowFirstOfTable.ClickOnElement();
        }
        public void WaitForTableDisplay()
        {
            _tblAssignment.WaitForElementToBeVisible();
        }
        public void SearchForAssignment(string criteria){
            _txtSearchBox.InputText(criteria);
            _txtSearchBox.PressEnter();
        }
        public void ClickOnEditButton(){
            WaitForTableDisplay();
            _btnRow("update").ClickOnElement();
        }
        public void DeleteAssignment(){
            WaitForTableDisplay();
            _btnRow("delete").ClickOnElement();
            _btnDelete.ClickOnElement();
        }
    }
}