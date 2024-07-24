using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Core.Reports;
using AssetManagement.Model;
using AssetManagement.PageObjects.Pages;
using AssetManagement.Service.Model.Response;
using AssetManagement.Service.Service;
using NUnit.Framework;

namespace AssetManagement.Test.UI.ManageUser
{
    [TestFixture, Category("ChangePassword")]
    // [Parallelizable(ParallelScope.Self)]
    public class ChangePasswordTest:BaseTest
    {
        private ChangePasswordPage _changePasswordPage;
        [SetUp]
        public new async Task Setup()
        {
            ReportLog.Info("Login into system as Admin");
            LoginAsAdmin();
            _changePasswordPage = new();        }

        [Test]
        [TestCase("Test1234")]
        public void TC_ChangePasswordSuccessfully(string newPassword)
        {
            var account = Hook.Accounts["admin"]; 
            ReportLog.Info("Open Change Password popup");
            _changePasswordPage.OpenChangePasswordPopup();
            ReportLog.Info($"Change password with {newPassword}");
            _changePasswordPage.ChangePassword(account.Password, newPassword);
            ReportLog.Info("Verify change Password successfully");
            _changePasswordPage.VerifyChangePassword();

            _changePasswordPage.RechangePassword(newPassword, account.Password);
        }
    }
}