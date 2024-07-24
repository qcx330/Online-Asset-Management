using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Constant;
using AssetManagement.Core.Reports;
using AssetManagement.PageObjects.Pages;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;

namespace AssetManagement.Test.UI.ManageUser
{
    [TestFixture, Category("CreateUser")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class CreateUserTest:BaseTest
    {
        private CreateNewUserPage _createUserPage;
        private DetailUserPage _detailUserPage;
        [SetUp]
        public new void Setup()
        {
            ReportLog.Info("Login into system as Admin");
            LoginAsAdmin();
            _createUserPage = new();
            _detailUserPage = new();
        }
        [Test]
        [TestCase("userStaff")]
        [TestCase("userAdmin")]
        public void TC_CreateUserSuccessfully(string userDataKey)
        {
            var user = Hook.Users[userDataKey];
            ReportLog.Info("Navigate to Manage User tab");
            _createUserPage.NavigateSubmenuLink("Manage User");
            ReportLog.Info("Navigate go Create User page");
            _createUserPage.ClickOnCreateUserButton();
            ReportLog.Info("Create new User");
            _createUserPage.CreateNewUser(user);
            ReportLog.Info("Verify create User successfully");
            _createUserPage.VerifyNotificationDisplayed(MessageConstant.CreateUserSuccessfully);
            _detailUserPage.VerifyUserInformation(user);
        }
        [Test]
        public void TC_SaveButtonIsDisableWhenLeaveEmptyFields()
        {
            ReportLog.Info("Navigate to Manage User tab");
            _createUserPage.NavigateSubmenuLink("Manage User");
            ReportLog.Info("Navigate go Create User page");
            _createUserPage.ClickOnCreateUserButton();
            ReportLog.Info("Leave fields empty");
            ReportLog.Info("Verify Save button is disabled");
            _createUserPage.VerifySaveButtonIsDisabled();     
        }
        [Test]
        [TestCase("userInvalidDate")]
        public void TC_CreateUserUnsuccessfullyWhenJoinedDayAfterDoB(string userDataKey)
        {
            var user = Hook.Users[userDataKey];
            ReportLog.Info("Navigate to Manage User tab");
            _createUserPage.NavigateSubmenuLink("Manage User");
            ReportLog.Info("Navigate go Create User page");
            _createUserPage.ClickOnCreateUserButton();
            ReportLog.Info("Create new User");
            _createUserPage.CreateNewUser(user);
            ReportLog.Info("Verify create User unsuccessfully");
            _createUserPage.VerifyNotificationDisplayed(MessageConstant.JoinedDateAfterDoB);
        }
        [Test]
        [TestCase("userInvalidJoinedDate")]
        public void TC_CreateUserUnsuccessfullyWhenInvalidJoinedDay(string userDataKey)
        {
            var user = Hook.Users[userDataKey];
            ReportLog.Info("Navigate to Manage User tab");
            _createUserPage.NavigateSubmenuLink("Manage User");
            ReportLog.Info("Navigate go Create User page");
            _createUserPage.ClickOnCreateUserButton();
            ReportLog.Info("Create new User");
            _createUserPage.CreateNewUser(user);
            ReportLog.Info("Verify create User unsuccessfully");
            _createUserPage.VerifyNotificationDisplayed(MessageConstant.InvalidJoinedDate);
        }
    }
}