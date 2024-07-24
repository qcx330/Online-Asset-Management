using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Constant;
using AssetManagement.Core.Reports;
using AssetManagement.PageObjects.Pages.ManageAssignment;
using NUnit.Framework;

namespace AssetManagement.Test.UI.ManageAssignment
{
    [TestFixture, Category("CreateAssignment")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class CreateAssignmentTest:BaseTest
    {
        private CreateAssignmentPage _createAssignmentPage;
        private DetailAssignmentPage _detailAssignmentPage;
        [SetUp]
        public new void Setup()
        {
            ReportLog.Info("Login into system as Admin");
            LoginAsAdmin();
            _createAssignmentPage = new();
            _detailAssignmentPage = new();
        }

        [Test]
        [TestCase("assignmentAllFields")]
        [TestCase("assignmentRequireFields")]
        public void TC_CreateAssignmentSuccessfully(string assignKey)
        {
            var assignment = Hook.Assignments[assignKey];
            ReportLog.Info("Navigate to Manage Assignment tab");
            _createAssignmentPage.NavigateSubmenuLink("Manage Assignment");
            ReportLog.Info("Navigate go Create Assignment page");
            _createAssignmentPage.ClickOnCreateAssignmentButton();
            ReportLog.Info("Create new Assignment");
            _createAssignmentPage.CreateAssignment(assignment);
            ReportLog.Info("Verify create Assign?ment successfully");
            _createAssignmentPage.VerifyNotificationDisplayed(MessageConstant.CreateAssignmentSuccessfully);
            _detailAssignmentPage.VerifyAssignmentInformation(assignment);
        }
    }
}