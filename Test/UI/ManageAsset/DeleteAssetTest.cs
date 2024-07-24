using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Constant;
using AssetManagement.Core.Reports;
using AssetManagement.PageObjects.Pages;

namespace AssetManagement.Test.UI.ManageAsset
{
    [TestFixture, Category("DeleteAsset")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class DeleteAssetTest : BaseTest
    {
        private ManageAssetPage _manageAssetPage;
        private CreateAssetpage _createAssetPage;
        [SetUp]
        public new void Setup()
        {
            ReportLog.Info("Login into system as Admin");
            LoginAsAdmin();
            _manageAssetPage = new();
            _createAssetPage = new();
        }
        [Test]
        [TestCase("assetDelete")]
        public void TC_DeleteAssetSuccessfully(string assetDataKey)
        {
            var asset = Hook.Assets[assetDataKey];
            ReportLog.Info("Navigate to Manage Asset tab");
            _manageAssetPage.NavigateSubmenuLink("Manage Asset");
            ReportLog.Info("Navigate go Create User page");
            _manageAssetPage.ClickOnCreateAssetButton();
            ReportLog.Info("Create new Asset");
            _createAssetPage.CreateAsset(asset);
            ReportLog.Info("Delete created asset");
            _manageAssetPage.DeleteAsset();
            _manageAssetPage.VerifyNotificationDisplayed(MessageConstant.DeleteAssetSuccessfully);
            ReportLog.Info($"Search for staff {asset.Name}");
            _manageAssetPage.SearchForAsset(asset.Name);
            ReportLog.Info("Verify user is not shown in table result");
            _manageAssetPage.VerifyNoResultFound();
        }
    }

}