using System.Collections.Generic;
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


    public class EquipmentData:Equipment
    {
        public EquipmentData()
        {
        }

        public EquipmentData( IEnumerable<Process> process, Equipment equipment)
        {
            this.Process = process;
            this.Id = equipment.Id;
            this.EquipmentName = equipment.EquipmentName;
            this.EquipmentState = equipment.EquipmentState;
            this.VacuumPressure = equipment.VacuumPressure;
            this.ProcessCount = equipment.ProcessCount;
        }
        [JsonProperty("Process")]
        public IEnumerable<Process> Process { get; set; }
    }
}
