using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [ForeignKey("Categories")]
        [Required(ErrorMessage = "Provide category")]
        public int CategoryID { get; set; }
        public Categories Categories { get; set; }

        [ForeignKey("Brands")]
        [Required(ErrorMessage = "Provide brand")]
        public int BrandID { get; set; }
        public Brands Brands { get; set; }

        [Required(ErrorMessage = "Provide name of product")]
        [Column(TypeName = "varchar(55)")]
        [DataType(DataType.Text, ErrorMessage = "Invalid title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Provide product price")]
        [Column(TypeName = "decimal(10, 2)")]
        [DataType(DataType.Currency, ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        [MaxLength(255)]
        [DataType(DataType.MultilineText, ErrorMessage = "Invalid description")]
        public string? Description { get; set; }
    }
}
