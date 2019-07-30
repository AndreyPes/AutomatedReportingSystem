using Newtonsoft.Json;

namespace BusinessLogic.BL.Common.GeneralDataModel
{
    public class Spectrum
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("ProcessID")]
        public int ProcessID { get; set; }
        [JsonProperty("MeasValue1")]
        public decimal MeasValue1 { get; set; }
        [JsonProperty("MeasValue2")]
        public decimal MeasValue2 { get; set; }
        [JsonProperty("MeasValue3")]
        public decimal MeasValue3 { get; set; }
    }
}
