using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.core;
using OpenQA.Selenium;

namespace AssetManagement.PageObjects.Pages
{
    public class ManageAssetPage:BasePage
    {
        private Element _tblAsset = new(By.TagName("table"));
        private Element _btnCreateAsset = new(By.XPath("//a[.='Create Asset']"));
        private Element _rowFirstOfTable = new(By.CssSelector("tbody tr:first-child"));
        private Element _btnDeleteFirstRowOfTable = new(By.CssSelector("tbody tr:first-child button:last-child"));
        private Element _txtSearchBox = new(By.CssSelector("input[type='text']"));
        private Element _lblNoAsset = new(By.XPath("//p[.='There is no asset!']"));
        private Element _btnDelete = new(By.XPath("//button[.='Delete']"));
         
        public void ClickOnCreateAssetButton()
        {
            _btnCreateAsset.ClickOnElement();
        }
        public void WaitForTableDisplay()
        {
            _tblAsset.WaitForElementToBeVisible();
        }
        public void ClickOnFirstRowOfTableUser()
        {
            _rowFirstOfTable.ClickOnElement();
        }
        public void DeleteAsset(){
            WaitForTableDisplay();
            _btnDeleteFirstRowOfTable.ClickOnElement();
            _btnDelete.ClickOnElement();
        }
        public void SearchForAsset(string criteria){
            _txtSearchBox.InputText(criteria);
            _txtSearchBox.PressEnter();
        }
        public void VerifyNoResultFound(){
            Assert.That(_lblNoAsset.IsDisplayed(), Is.True);
        }
    }
}