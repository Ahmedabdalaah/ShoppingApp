using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Areas.Peport.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [ForeignKey("transaction")]
        [Display(Name ="Transaction")]
        public int TransactionId { get; set; }
        public Transaction? transaction { get; set; }
        ICollection<EmpTransaction> employees { get; set; }
    }
}
