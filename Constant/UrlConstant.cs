using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Configuration;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AssetManagement.Constant
{
    public class UrlConstant
    {
        private static string baseUrl => ConfigurationHelper.GetConfiguration()["BaseUrl"];
        public static readonly string LoginUrl = $"{baseUrl}/login";
    }
}