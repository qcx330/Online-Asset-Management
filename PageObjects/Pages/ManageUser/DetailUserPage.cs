using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AssetManagement.core;
using AssetManagement.Core.Driver;
using AssetManagement.ManageAssetUtils;
using AssetManagement.Model;
using FluentAssertions;
using OpenQA.Selenium;

namespace AssetManagement.PageObjects.Pages
{
    public class DetailUserPage : ManageUserPage
    {
        private Element _rowUserDetail(string field) => new(By.XPath($"//span[.='{field}']//following-sibling::span"));
        public void VerifyUserInformation(UserDto user)
        {
            WaitForTableDisplay();
            ClickOnFirstRowOfTableUser();
            VerifyFullName(user.FirstName, user.LastName);
            VerifyUserName(user.FirstName, user.LastName);
            VerifyDayOfBirth(user.DateOfBirth);
            VerifyGender(user.Gender);
            VerifyJoinedDate(user.JoinedDate);
            VerifyType(user.Type);
        }
        public void VerifyFullName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return;
            _rowUserDetail("Full Name").GetTextFromElement().Should().Be(firstName + " " + lastName);
        }
        public void VerifyUserName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return;
            _rowUserDetail("Username").GetTextFromElement().Should().Contain(Utils.FormatUsername(firstName, lastName));
        }
        public void VerifyDayOfBirth(string dateOfBirth)
        {
            _rowUserDetail("Day of Birth").GetTextFromElement().Should().Be(Utils.FormatDate(dateOfBirth));
        }
        public void VerifyGender(string gender)
        {
            if (string.IsNullOrEmpty(gender))
                return;
            _rowUserDetail("Gender").GetTextFromElement().Should().Be(gender);
        }
        public void VerifyJoinedDate(string joinedDate)
        {
            if (string.IsNullOrEmpty(joinedDate))
                return;
            _rowUserDetail("Joined Date").GetTextFromElement().Should().Be(Utils.FormatDate(joinedDate));
        }
        public void VerifyType(string type)
        {
            if (string.IsNullOrEmpty(type))
                return;
            _rowUserDetail("Type").GetTextFromElement().Should().Be(type);
        }
    }
}