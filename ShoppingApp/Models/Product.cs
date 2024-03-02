using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime? CreatTime { get; set; } = DateTime.Now;
        [ForeignKey("category")]
        [Display(Name = "category")]
        public int CategoryId { get; set; }
        public Category? category { get; set; }  


    }
}
