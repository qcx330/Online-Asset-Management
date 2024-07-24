using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Core.API;
using AssetManagement.Core.Driver;
using AssetManagement.Core.Reports;
using AssetManagement.Model;
using AssetManagement.PageObjects.Pages;
using AssetManagement.Service.Service;
using Core.Configuration;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;

namespace AssetManagement.Test.UI
{
    [TestFixture]
    public class BaseTest
    {
        protected LoginPage LoginPage;
        protected static APIClient ApiClient;
        UserService _userService;
        public BaseTest(){
            ExtentTestManager.CreateParentTest(TestContext.CurrentContext);
            ApiClient = new APIClient(ConfigurationHelper.GetConfiguration()["baseAPI"]);
            _userService = new(ApiClient);
        }
        [SetUp]
        public void Setup()
        {
            string browser = ConfigurationHelper.GetConfiguration()["browser"];
            double timeOutSec = double.Parse(ConfigurationHelper.GetConfiguration()["timeout.webdriver.wait.seconds"]);
            
            ExtentTestManager.CreateTest(TestContext.CurrentContext);
            ReportLog.Info("Initialize webdriver");
            
            
            DriverManager.InitializeBrowser(browser);
            DriverManager.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOutSec);
            LoginPage = new();
            LoginPage.GoToUrl(Constant.UrlConstant.LoginUrl);
            Console.WriteLine("Base Test set up"); 
        }
        protected void LoginAsAdmin()
        {
            var account = Hook.Accounts["admin"];
            LoginPage.Login(account);
            DriverManager.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        protected void LoginAsStaff()
        {
            var account = Hook.Accounts["staff"];
            LoginPage.Login(account);
            DriverManager.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        protected async Task GenerateToken(){
            var account = Hook.Accounts["admin"];
            await _userService.GenerateToken(account.Username, account.Password);
        }
        
        [TearDown]
        public void TearDown()
        {
            ExtentTestManager.LogTestOutcome(TestContext.CurrentContext ,DriverManager.WebDriver);

            DriverManager.CloseDriver();
            ReportLog.Info("Close webdriver");
            Console.WriteLine("Base Test tear down");
        }
    }
}
