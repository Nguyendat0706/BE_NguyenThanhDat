using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_NguyenThanhDat.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required, StringLength(255)]
        public string ProductName { get; set; }

        [Required]
        public string ProductDecription { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        public string ProductImage { get; set; }

        // Liên kết với Category
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
