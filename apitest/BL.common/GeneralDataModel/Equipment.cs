using Newtonsoft.Json;

namespace BusinessLogic.BL.Common.GeneralDataModel
{
    public class Equipment
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("EquipmentName")]
        public string EquipmentName { get; set; }
        [JsonProperty("EquipmentState")]
        public string EquipmentState { get; set; }
        [JsonProperty("VacuumPressure")]
        public decimal VacuumPressure { get; set; }
        [JsonProperty("ProcessCount")]
        public int ProcessCount { get; set; }
    }
}
