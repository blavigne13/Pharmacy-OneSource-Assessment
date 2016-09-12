namespace Pharmacy_OneSource_Assessment.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductCode { get; set; }

        [Required]
        [StringLength(50)]
        public string InvoiceLabel { get; set; }

        public double Price { get; set; }

        [Required]
        [StringLength(50)]
        public string TaxCode { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public int? Stock { get; set; }
    }
}