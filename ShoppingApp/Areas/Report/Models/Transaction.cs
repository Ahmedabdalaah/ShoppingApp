using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Areas.Peport.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? TransTime { get; set; } = DateTime.Now;
        ICollection<EmpTransaction> transactions { get; set; }
    }
}
