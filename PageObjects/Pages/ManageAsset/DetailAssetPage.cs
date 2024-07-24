using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.core;
using AssetManagement.ManageAssetUtils;
using AssetManagement.Model;
using FluentAssertions;
using OpenQA.Selenium;

namespace AssetManagement.PageObjects.Pages
{
    public class DetailAssetPage:ManageAssetPage
    {
        private Element _rowUserDetail(string field) => new(By.XPath($"//span[.='{field}']//following-sibling::span"));
        public void VerifyAssetInformation(AssetDto asset){
            WaitForTableDisplay();
            ClickOnFirstRowOfTableUser();
            VerifyName(asset.Name);
            VerifyCategory(asset.Category);
            VerifyInstalledDate(asset.InstalledDate);
            VerifySpecification(asset.Specification);
            VerifyState(asset.State);
            VerifyHistory();
        }
        public void VerifyName(string name){
            _rowUserDetail("Asset Name").GetTextFromElement().Should().Be(Utils.FormatAssetName(name));
        }
        public void VerifyCategory(string category){
            _rowUserDetail("Category").GetTextFromElement().Should().Contain(category);
        }
        public void VerifyInstalledDate(string installedDate){
            _rowUserDetail("Installed Date").GetTextFromElement().Should().Be(Utils.FormatDate(installedDate));
        }
        public void VerifyState(string state){
            _rowUserDetail("State").GetTextFromElement().Should().Be(state);
        }
        public void VerifySpecification(string specification){
            _rowUserDetail("Specification").GetTextFromElement().Should().Be(specification);
        }
        public void VerifyHistory(){
            _rowUserDetail("History").GetTextFromElement().Should().Be("No history");
        }
    }
}