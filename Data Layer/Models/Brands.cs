using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Models
{
    public class Brands
    {
        [Key]
        public int BrandID { get; set; }

        [DataType(DataType.Text, ErrorMessage = "Invalid title")]
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText, ErrorMessage = "Invalid description")]
        [MaxLength(255)]
        public string? Description { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        public ICollection<Products>? Products { get; set; }
    }
}
