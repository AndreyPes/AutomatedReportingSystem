namespace apitest.EquipmentEntity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("State")]
    public partial class State
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string EquipmentName { get; set; }

        [Required]
        [StringLength(100)]
        public string EquipmentState { get; set; }

        public decimal VacuumPressure { get; set; }

        public int ProcessCount { get; set; }
    }
}
