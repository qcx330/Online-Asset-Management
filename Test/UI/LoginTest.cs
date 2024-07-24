using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Constant;
using AssetManagement.Core.Reports;
using AssetManagement.Model;
using AssetManagement.PageObjects.Pages;
using NUnit.Framework;

namespace AssetManagement.Test.UI
{
    [TestFixture, Category("Login")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class LoginTest:BaseTest
    {
        [Test]
        [TestCase("admin")]
        public void TC_AdminUserLoginSuccessfully(string accountDataKey)
        {
            var account = Hook.Accounts[accountDataKey] as AccountDto;
            ReportLog.Info($"Login in with {accountDataKey} data");
            LoginPage.Login(account);
            ReportLog.Info("Verify login successfully");
            LoginPage.VerifyNotificationDisplayed(MessageConstant.LoginSuccessfully);
            LoginPage.VerifyAdminUserLoginSuccessfully();
        }
        [Test]
        [TestCase("staff")]
        public void TC_StaffUserLoginSuccessfully(string accountDataKey)
        {
            var account = Hook.Accounts[accountDataKey] as AccountDto;
            ReportLog.Info($"Login in with {accountDataKey} data");
            LoginPage.Login(account);
            ReportLog.Info("Verify login successfully");
            LoginPage.VerifyNotificationDisplayed(MessageConstant.LoginSuccessfully);
            LoginPage.VerifyStaffUserLoginSuccessfully();
        }
        [Test]
        [TestCase("invalidUsername")]
        [TestCase("invalidPassword")]
        public void TC_LoginUnsucessfullyByInvalidData(string accountDataKey)
        {
            var account = Hook.Accounts[accountDataKey] as AccountDto;
            ReportLog.Info($"Login in with {accountDataKey} data");
            LoginPage.Login(account);
            ReportLog.Info("Verify login unsuccessfully with invalid data");
            LoginPage.VerifyNotificationDisplayed(MessageConstant.InvalidUsernamePassword);
        }
        [Test]
        public void TC_LoginUnsucessfullyWhenLeaveFieldsEmpty()
        {
            ReportLog.Info($"Leave username and password fields empty");
            ReportLog.Info("Verify Login button is not enabled");
            LoginPage.VerifyLoginButtonDisabled();
        }
    }
}