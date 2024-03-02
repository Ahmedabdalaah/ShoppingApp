using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Areas.Peport.Models
{
    public class EmpTransaction
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("employee")]
        public int EmployeeId { get; set; }
        public Employee? employee { get; set; }
        [ForeignKey("transaction")]
        public int TransId { get; set; }
        public Transaction? transaction { get; set; }
    }
}
