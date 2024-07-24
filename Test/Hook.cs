using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Constant;
using AssetManagement.Core.Reports;
using AssetManagement.Model;
using Core.Configuration;
using Core.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V123.Page;

namespace AssetManagement.Test
{
    [SetUpFixture]
    public class Hook
    {
        public static Dictionary<string, UserDto> Users;
        public static Dictionary<string, AccountDto> Accounts;
        public static Dictionary<string, AssetDto> Assets;
        public static Dictionary<string, AssignmentDto> Assignments;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var config = ConfigurationHelper.ReadConfiguration(JsonPathConstant.AppSettingPath);
            ExtentReportManager.AddSystemInfo("Enviroment", config["enviroment"]);
            ExtentReportManager.AddSystemInfo("Browser", config["browser"]);

            Users = JsonUtils.ReadDictionaryJson<Dictionary<string, UserDto>>(JsonPathConstant.UsersPath);
            Accounts = JsonUtils.ReadDictionaryJson<Dictionary<string, AccountDto>>(JsonPathConstant.AccountsPath);
            Assets = JsonUtils.ReadDictionaryJson<Dictionary<string, AssetDto>>(JsonPathConstant.AssetsPath);
            Assignments = JsonUtils.ReadDictionaryJson<Dictionary<string, AssignmentDto>>(JsonPathConstant.AssignmentsPath);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentReportManager.GenerateReport();
        }
    }
}