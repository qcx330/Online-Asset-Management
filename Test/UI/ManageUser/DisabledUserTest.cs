using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Io;
using AssetManagement.Constant;
using AssetManagement.Core.API;
using AssetManagement.Core.Reports;
using AssetManagement.PageObjects.Pages;
using AssetManagement.Service.Model.Request;
using AssetManagement.Service.Service;
using Core.Utilities;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AssetManagement.Test.UI.ManageUser
{
    [TestFixture, Category("DisabledUser")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class DisabledUserTest : BaseTest
    {
        private ManageUserPage _manageUserPage;
        private CreateNewUserPage _createUserPage;

        [SetUp]
        public new async Task Setup()
        {
            ReportLog.Info("Login into system as Admin");
            LoginAsAdmin();
            _manageUserPage = new();
            _createUserPage = new();
        }
        [Test]
        [TestCase("userDisabled")]
        public void TC_DisabledUserSuccessfully(string userDataKey)
        {
            var user = Hook.Users[userDataKey];

            ReportLog.Info("Navigate to Manage User tab");
            _manageUserPage.NavigateSubmenuLink("Manage User");
            ReportLog.Info("Navigate go Create User page");
            _manageUserPage.ClickOnCreateUserButton();
            ReportLog.Info("Create new User");
            _createUserPage.CreateNewUser(user);
            ReportLog.Info("Disabled created user");
            _manageUserPage.ClickOnDisabledButtonOfFirstRowOfTable();
            _manageUserPage.ClickOnDisableUserButton();
            _manageUserPage.VerifyNotificationDisplayed(MessageConstant.DisableUserSuccessfully);
            ReportLog.Info($"Search for staff {user.FirstName} {user.LastName}");
            _manageUserPage.SearchByCriteria(user.FirstName + " " + user.LastName);
            ReportLog.Info("Verify user is not shown in table result");
            _manageUserPage.VerifyNoResultFound();
        }
    }
}