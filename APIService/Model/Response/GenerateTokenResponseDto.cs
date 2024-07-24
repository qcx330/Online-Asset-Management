using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AssetManagement.Service.Model.Response
{
    public class GenerateTokenResponseDto
    {
        [JsonProperty("data")]
        public string Data { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
    }
}