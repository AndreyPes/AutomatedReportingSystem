using Newtonsoft.Json;
using System;

namespace BusinessLogic.BL.Common.GeneralDataModel
{
    public class OperationList
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("ProcessID")]
        public int ProcessID { get; set; }
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("RecipeName")]
        public string RecipeName { get; set; }
        [JsonProperty("Time")]
        public TimeSpan? Time { get; set; }
        [JsonProperty("Parameter")]
        public string Parameter { get; set; }
    }
}
