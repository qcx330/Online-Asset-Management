using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AssetManagement.Core.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace AssetManagement.Core.Reports
{
    public class ExtentTestManager
    {
        private static AsyncLocal<ExtentTest> _parentTest = new AsyncLocal<ExtentTest>();
        private static AsyncLocal<ExtentTest> _childTest = new AsyncLocal<ExtentTest>();

        public static ExtentTest CreateParentTest(TestContext context, string description = null)
        {
            _parentTest.Value = ExtentReportManager.Instance.CreateTest(context.Test.ClassName, description);
            return _parentTest.Value;
        }

        public static ExtentTest CreateTest(TestContext context, string description = null)
        {
            _childTest.Value = _parentTest.Value.CreateNode(context.Test.Name, description);
            return _childTest.Value;
        }

        public static ExtentTest GetTest()
        {
            return _childTest.Value;
        }
        public static void LogTestOutcome(TestContext context, IWebDriver driver)
        {
            var outcome = context.Result.Outcome.Status;
            var stackTrace = string.IsNullOrEmpty(context.Result.StackTrace)
                ? ""
                : string.Format("<pre>{0}</pre>", context.Result.StackTrace);
            Status logStatus;
            var className = context.Test.ClassName;
            var testName = context.Test.Name;
            switch (outcome)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    var fileLocation = ScreenshotHelper.CaptureScreenshot(driver, className, testName);
                    testName = FileUtils.SanitizeFileName(testName);
                    var mediaEntity = ScreenshotHelper.CaptureScreenShotAndAttachToExtendReport(fileLocation);
                    ReportLog.Fail($"#Test Name:  {testName}  #Status:  {logStatus} {stackTrace}", mediaEntity);
                    // ReportLog.Fail("#Screenshot Below: " + ReportLog.AddScreenCaptureFromPath(fileLocation));
                    break;
                case TestStatus.Inconclusive:
                    logStatus = Status.Warning;
                    ReportLog.Skip("#Test Name: " + testName + " #Status: " + logStatus);
                    break;
                case TestStatus.Skipped:
                    logStatus = Status.Skip;
                    ReportLog.Skip("#Test Name: " + testName + " #Status: " + logStatus);
                    break;
                default:
                    logStatus = Status.Pass;
                    ReportLog.Pass("#Test Name: " + testName + " #Status: " + logStatus);
                    break;
            }
            // GetTest().Log(logStatus, "Test ended with " + logStatus + stackTrace);
        }

    }
}