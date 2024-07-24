using AssetManagement.Constant;
using AssetManagement.Core.Reports;
using AssetManagement.PageObjects.Pages.ManageAssignment;

namespace AssetManagement.Test.UI.ManageAssignment
{
  [TestFixture, Category("DeleteAssignment")]
  // [Parallelizable(ParallelScope.Fixtures)]
  public class DeleteAssignmentTest : BaseTest
  {
    private DeleteAssignmentModal _deleteAssignmentModal;
    [SetUp]
    public new void Setup()
    {
      ReportLog.Info("Login into system as Admin");
      LoginAsAdmin();
      _deleteAssignmentModal = new();
    }

    [Test]
    [TestCase("assignmentDelete")]
    public void TC_DeleteAssignmentSuccessfully(string assignKey)
    {
      var assignment = Hook.Assignments[assignKey];
      ReportLog.Info("Navigate to Manage Assignment tab");
      _deleteAssignmentModal.NavigateSubmenuLink("Manage Assignment");
      ReportLog.Info($"Search for Assignment {assignment.Asset}");
      _deleteAssignmentModal.SearchForAssignment(assignment.Asset);
      ReportLog.Info("Delete selected Assignment");
      _deleteAssignmentModal.DeleteAssignment();
      ReportLog.Info("Verify Assignment is deleted successfully");
      _deleteAssignmentModal.VerifyNotificationDisplayed(MessageConstant.DeleteAssignmentSuccessfully);
    }
  }
}