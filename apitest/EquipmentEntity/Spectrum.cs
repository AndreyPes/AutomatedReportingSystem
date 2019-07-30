namespace apitest.EquipmentEntity
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Spectrum")]
    public partial class Spectrum
    {
        public int ID { get; set; }

        public int ProcessID { get; set; }

        public decimal MeasValue1 { get; set; }

        public decimal MeasValue2 { get; set; }

        public decimal MeasValue3 { get; set; }

        public virtual Process Process { get; set; }
    }
}
