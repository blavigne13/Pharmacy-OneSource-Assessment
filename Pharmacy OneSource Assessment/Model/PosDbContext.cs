namespace Pharmacy_OneSource_Assessment.Model
{
    using System.Data.Entity;

    public partial class PosDbContext : DbContext
    {
        public PosDbContext()
            : base("name=PosDbContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.State)
                .IsFixedLength();

            modelBuilder.Entity<Address>()
                .Property(e => e.Zip)
                .IsFixedLength();

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Address)
                .HasForeignKey(e => e.BillingAddressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Customers1)
                .WithRequired(e => e.Address1)
                .HasForeignKey(e => e.ShippingAddressId)
                .WillCascadeOnDelete(false);
        }
    }
}