using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AssetManagement.Model
{
    public class AssignmentDto
    {
        [JsonProperty("User")]
        public string User { get; set; }

        [JsonProperty("Asset")]
        public string Asset { get; set; }

        [JsonProperty("AssignDate")]
        public string AssignDate { get; set; }

        [JsonProperty("Note")]
        public string Note { get; set; }
    }
}