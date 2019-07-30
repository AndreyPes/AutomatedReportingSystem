namespace apitest.EquipmentEntity
{
    using System.Data.Entity;

    public partial class EquipmentEF : DbContext
    {
        public EquipmentEF()
            : base("name=EquipmentEF")
        {
        }

        public virtual DbSet<OperationList> OperationList { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Spectrum> Spectrum { get; set; }
        public virtual DbSet<State> State { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Process>()
                .HasMany(e => e.Operation_List)
                .WithRequired(e => e.Process)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Process>()
                .HasMany(e => e.Spectrum)
                .WithRequired(e => e.Process)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Spectrum>()
                .Property(e => e.MeasValue1)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Spectrum>()
                .Property(e => e.MeasValue2)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Spectrum>()
                .Property(e => e.MeasValue3)
                .HasPrecision(10, 3);

            modelBuilder.Entity<State>()
                .Property(e => e.VacuumPressure)
                .HasPrecision(10, 3);
        }
    }
}
