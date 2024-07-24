using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AssetManagement.Model
{
    public class AccountDto
    {
        [JsonProperty("username")]
        public string Username {get; set;}
        [JsonProperty("password")]
        public string Password {get; set;}
    }
}