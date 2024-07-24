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
    [TestFixture, Category("EditAssignment")]
    // [Parallelizable(ParallelScope.Fixtures)]
    public class EditAssignmentTest :BaseTest
    {
        private EditAssignmentPage _editAssignmentPage;
        private DetailAssignmentPage _detailAssignmentPage;
        [SetUp]
        public new void Setup()
        {
            ReportLog.Info("Login into system as Admin");
            LoginAsAdmin();
            _editAssignmentPage = new();
            _detailAssignmentPage = new();
        }

        [Test]
        [TestCase("assignmentUpdate")]
        public void TC_EditAssignmentSuccessfully(string assignKey)
        {
            var assignment = Hook.Assignments[assignKey];
            ReportLog.Info("Navigate to Manage Assignment tab");
            _editAssignmentPage.NavigateSubmenuLink("Manage Assignment");
            ReportLog.Info($"Search for Assignment {assignment.Asset}");
            _editAssignmentPage.SearchForAssignment(assignment.Asset);
            _editAssignmentPage.ClickOnEditButton();
            ReportLog.Info("Edit selected User");
            _editAssignmentPage.EditAssignment(assignment);
            ReportLog.Info("Verify create Assign?ment successfully");
            _editAssignmentPage.VerifyNotificationDisplayed(MessageConstant.EditAssignmentSuccessfully);
            _detailAssignmentPage.VerifyAssignmentInformation(assignment);
        }
    }
}