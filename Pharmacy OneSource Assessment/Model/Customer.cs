namespace Pharmacy_OneSource_Assessment.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        [Key]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public int BillingAddressId { get; set; }

        public int ShippingAddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual Address Address1 { get; set; }
    }
}