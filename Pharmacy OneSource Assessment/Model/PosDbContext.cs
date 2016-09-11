namespace Pharmacy_OneSource_Assessment.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

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

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomerEmail)
                .WillCascadeOnDelete(false);
        }
    }
}
