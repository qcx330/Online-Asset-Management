using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AssetManagement.core;
using AssetManagement.ManageAssetUtils;
using AssetManagement.Model;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;

namespace AssetManagement.PageObjects.Pages
{
    public class CreateAssetpage : ManageAssetPage
    {
        private Element _txtField(string field) => new(By.Id($"{field}"));
        private Element _ddlCategory = new(By.Id("category"));
        private Element _chkState(string state) => new(By.XPath($"//label[.='{state}']//preceding-sibling::input"));
        private Element _optCateogry(string option) => new(By.XPath($"//p[.='{option}']"));
        private Element _btnSave = new(By.XPath("//button[.='Save']"));
        private Element _btnAddNewCategory = new(By.XPath("//button[.='Add new category']"));

        //Create new Category
        private Element _btnSubmit = new(By.Id("done"));
        public void CreateAsset(AssetDto asset)
        {
            EnterName(asset.Name);
            SelectCategory(asset.Category);
            EneterSpecification(asset.Specification);
            EnterInstalledDate(asset.InstalledDate);
            SelectState(asset.State);
            ClickOnSaveButton();
        }
        public void CreateAssetAndCategory(AssetDto asset)
        {
            string cate = CreateCategory(asset.Category);
            _ddlCategory.ClickOnElement();
            EnterName(asset.Name);
            SelectCategory(cate);
            EneterSpecification(asset.Specification);
            EnterInstalledDate(asset.InstalledDate);
            SelectState(asset.State);
            ClickOnSaveButton();
        }
        public string CreateCategory(string category)
        {
            string cate;
            _ddlCategory.ClickOnElement();
            _btnAddNewCategory.ClickOnElement();
            do
            {   
                string randomInt = Utils.GenerateRandomNumber(0, 200).ToString();
                cate = category + randomInt;
                _txtField("category-name").ClearText();
                _txtField("category-name").InputText(cate);
                _txtField("category-code").ClearText();
                _txtField("category-code").InputText(Utils.NameToPrefix(cate)+randomInt);
                _btnSubmit.ClickOnElement();
                if (!IsNotiDisplayed("Category is already existed. Please enter a different category"))
                    break;
            } while (IsNotiDisplayed("Category is already existed. Please enter a different category"));
            return cate;
        }
        public void VerifySaveButtonIsDisabled()
        {
            Assert.That(_btnSave.IsEnabled(), Is.False, "Save button is enabled when leave field empty");
        }
        public void ClickOnSaveButton()
        {
            _btnSave.ClickOnElement();
        }
        public void EnterName(string name)
        {
            _txtField("name").InputText(name);
        }
        public void SelectCategory(string category)
        {
            _ddlCategory.ClickOnElement();
            _optCateogry(category).ClickOnElement();
        }
        public void EneterSpecification(string specification)
        {
            _txtField("Specification").InputText(specification);
        }
        public void EnterInstalledDate(string installedDate)
        {
            _txtField("installedDate").InputText(installedDate);
        }
        public void SelectState(string state)
        {
            _chkState(state).ClickOnElement();
        }

    }
}