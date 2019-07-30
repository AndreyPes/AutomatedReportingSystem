using Newtonsoft.Json;
using System.Collections.Generic;


namespace BL.BL.common.GeneralDataModel
{
    public class Process
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("RecipeName")]
        public string RecipeName { get; set; }
        [JsonProperty("CustomerName")]
        public string CustomerName { get; set; }
        [JsonProperty("OperatorName")]
        public string OperatorName { get; set; }
        [JsonProperty("PartName")]
        public string PartName { get; set; }
        [JsonProperty("OperationList")]
        public List<OperationList> OperationList { get; set; }
    }
}
