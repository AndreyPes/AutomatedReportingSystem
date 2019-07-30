using Newtonsoft.Json;
using System;

namespace BL.BL.common.GeneralDataModel
{
    public class LastProcess
    {
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("IsCompleted")]
        public bool IsCompleted { get; set; }
        [JsonProperty("IsFailed")]
        public bool IsFailed { get; set; }
    }
}
