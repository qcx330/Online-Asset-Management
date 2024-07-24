using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V123.HeapProfiler;

namespace AssetManagement.Service.Constant
{
    public class EndpointConstant
    {

        public const string GenerateTokenEndpoint = "/auth/login";
        public const string CreateUserEndpoint = "/account";
        public const string ChangePasswordEndpoint = "/auth/change-password";    
    }
}