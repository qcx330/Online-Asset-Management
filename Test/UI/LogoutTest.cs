using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Constant;
using AssetManagement.Core.Reports;
using AssetManagement.PageObjects.Pages;
using NUnit.Framework;

namespace AssetManagement.Test.UI
{
    [TestFixture, Category("Logout")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class LogoutTest:BaseTest
    {   
        [SetUp]
        public new void Setup()
        {
            ReportLog.Info("Login into system");
            LoginAsAdmin();
        }

        [Test]
        public void TC_LogoutSuccessfully()
        {
            ReportLog.Info("Click on Logout button from header");
            LoginPage.Logout();
            ReportLog.Info("Verify logout successfully");
            LoginPage.VerifyNotificationDisplayed(MessageConstant.LogoutSuccessfully);
            
        }
    }
}