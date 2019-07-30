namespace apitest.EquipmentEntity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OperationList")]
    public partial class OperationList
    {
        public int ID { get; set; }

        public int ProcessID { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string RecipeName { get; set; }

        public TimeSpan? Time { get; set; }

        [Required]
        [StringLength(50)]
        public string Parameter { get; set; }

        public virtual Process Process { get; set; }
    }
}
