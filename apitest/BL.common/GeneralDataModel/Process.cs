using Newtonsoft.Json;
using System.Collections.Generic;


namespace BusinessLogic.BL.Common.GeneralDataModel
{
    public class Process: LastProcess
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
