using System.ComponentModel.DataAnnotations;

namespace BE_NguyenThanhDat.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(255)]
        public string CategoryName { get; set; }
    }
}
