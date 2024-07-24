using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Constant;
using AssetManagement.Core.Reports;
using AssetManagement.PageObjects.Pages;
using NUnit.Framework;

namespace AssetManagement.Test.UI.ManageUser
{
    [TestFixture, Category("EditUser")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class EditUserTest : BaseTest
    {
        private EditUserPage _editUserPage;
        private DetailUserPage _detailUserPage;
        [SetUp]
        public new void Setup()
        {
            ReportLog.Info("Login into system as Admin");
            LoginAsAdmin();
            _editUserPage = new();
            _detailUserPage = new();
        }
        [Test]
        [TestCase("updateUser")]
        public void TC_EditUserSuccessfully(string userDataKey)
        {
            var user = Hook.Users[userDataKey];
            ReportLog.Info("Navigate to Manage User tab");
            _editUserPage.NavigateSubmenuLink("Manage User");
            ReportLog.Info($"Search for staff");
            _editUserPage.SearchForRandomStaffcode();
            _editUserPage.ClickOnEditButtonOfFirstRowOfTableUser();
            ReportLog.Info("Edit selected User");
            _editUserPage.EditUser(user);
            ReportLog.Info("Verify create User successfully");
            _editUserPage.VerifyNotificationDisplayed(MessageConstant.UpdateUserSuccessfully);
            _detailUserPage.VerifyUserInformation(user);
        }
    }
}