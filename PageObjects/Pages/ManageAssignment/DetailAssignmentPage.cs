using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.core;
using AssetManagement.ManageAssetUtils;
using AssetManagement.Model;
using FluentAssertions;
using OpenQA.Selenium;

namespace AssetManagement.PageObjects.Pages.ManageAssignment
{
    public class DetailAssignmentPage:ManageAssignmentPage
    {
        private Element _rowUserDetail(string field) => new(By.XPath($"//span[.='{field}']//following-sibling::span"));
        public void VerifyAssignmentInformation(AssignmentDto assignment){
            WaitForTableDisplay();
            ClickOnFirstRowOfTableUser();
            VerifyAssetName(assignment.Asset);
            VerifyAssignTo(assignment.User);
            VerifyAssignDate(assignment.AssignDate);
            VerifyNote(assignment.Note);
        }
        public void VerifyAssetName(string asset){
            if (string.IsNullOrEmpty(asset))
                return;
            asset.ToLower().Should().Contain(_rowUserDetail("Asset Name").GetTextFromElement());
        }
        public void VerifyAssignTo(string assignTo){
            if (string.IsNullOrEmpty(assignTo))
                return;
            Console.WriteLine(assignTo);
            _rowUserDetail("Assigned to").GetTextFromElement().Should().Contain(Utils.GetFirstNameFromFullName(assignTo.ToLower()));
        }
        public void VerifyAssignDate(string date){
            if (string.IsNullOrEmpty(date))
                return;
            _rowUserDetail("Assigned Date").GetTextFromElement().Should().Be(Utils.FormatDate(date));
        }
        public void VerifyNote(string note){
            if (string.IsNullOrEmpty(note))
                return;
            _rowUserDetail("Note").GetTextFromElement().Should().Contain(note);
        }
    }
}