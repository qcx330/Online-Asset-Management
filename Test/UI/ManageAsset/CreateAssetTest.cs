using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Constant;
using AssetManagement.Core.Reports;
using AssetManagement.PageObjects.Pages;

namespace AssetManagement.Test.UI.ManageAsset
{
    [TestFixture, Category("CreateAsset")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class CreateAssetTest:BaseTest
    {
        private CreateAssetpage _createAssetPage;
        private DetailAssetPage _detailAssetPage;
        [SetUp]
        public new void Setup()
        {
            ReportLog.Info("Login into system as Admin");
            LoginAsAdmin();
            _createAssetPage = new();
            _detailAssetPage = new();
        }
        [Test]
        [TestCase("asset")]
        public void TC_CreateAssetSuccessfully(string assetDataKey)
        {
            var asset = Hook.Assets[assetDataKey];
            ReportLog.Info("Navigate to Manage Asset tab");
            _createAssetPage.NavigateSubmenuLink("Manage Asset");
            ReportLog.Info("Navigate go Create Asset page");
            _createAssetPage.ClickOnCreateAssetButton();
            ReportLog.Info("Create new Asset");
            _createAssetPage.CreateAsset(asset);
            ReportLog.Info("Verify create Asset successfully");
            _createAssetPage.VerifyNotificationDisplayed(MessageConstant.CreateAssetSuccessfully);
            _detailAssetPage.VerifyAssetInformation(asset);
        }
        [Test]
        [TestCase("assetCategory")]
        public void TC_CreateAssetAndCategorySuccessfully(string assetDataKey)
        {
            var asset = Hook.Assets[assetDataKey];
            ReportLog.Info("Navigate to Manage Asset tab");
            _createAssetPage.NavigateSubmenuLink("Manage Asset");
            ReportLog.Info("Navigate go Create Asset page");
            _createAssetPage.ClickOnCreateAssetButton();
            ReportLog.Info("Create new Asset and Category");
            _createAssetPage.CreateAssetAndCategory(asset);
            ReportLog.Info("Verify create Asset successfully");
            _createAssetPage.VerifyNotificationDisplayed(MessageConstant.CreateAssetSuccessfully);
            _detailAssetPage.VerifyAssetInformation(asset);
        }
        [Test]
        public void TC_SaveButtonIsDisableWhenLeaveEmptyFields()
        {
            ReportLog.Info("Navigate to Manage User tab");
            _createAssetPage.NavigateSubmenuLink("Manage Asset");
            ReportLog.Info("Navigate go Create User page");
            _createAssetPage.ClickOnCreateAssetButton();
            ReportLog.Info("Leave fields empty");
            ReportLog.Info("Verify Save button is disabled");
            _createAssetPage.VerifySaveButtonIsDisabled();     
        }
    }
}