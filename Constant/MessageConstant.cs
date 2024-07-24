using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace AssetManagement.Constant
{
    public class MessageConstant
    {
        //Login
        public const string LoginSuccessfully = "Login successfully";
        public const string InvalidUsernamePassword = "Username or password is incorrect. Please try again";

        //Logout
        public const string LogoutSuccessfully = "Logout successfully";

        //User
        public const string CreateUserSuccessfully = "Account created sucessfully";
        public const string JoinedDateAfterDoB = "Joined date is not later than Date of Birth. Please select a different date";
        public const string InvalidJoinedDate = "Joined date is Saturday or Sunday. Please select a different date";
        public const string DisableUserSuccessfully = "Disable user successfully";
        public const string UpdateUserSuccessfully = "Update account successfully";
        public const string ChangePasswordSuccessfully = "Your password has been changed successfully!";

        //ASset
        public const string CreateAssetSuccessfully = "Create asset successfully";
        public const string DeleteAssetSuccessfully = "Delete asset successfully";

        //Assignment
        public const string CreateAssignmentSuccessfully = "Assignment created sucessfully";
        public const string EditAssignmentSuccessfully = "Assignment updated sucessfully";
        public const string DeleteAssignmentSuccessfully = "Assignment deleted sucessfully";

        //Home
        public const string CreateRequestReturningSuccessfully = "Create request successfully";
    }
}