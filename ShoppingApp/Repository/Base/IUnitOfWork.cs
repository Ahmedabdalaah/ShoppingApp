using ShoppingApp.Areas.Peport.Models;

namespace ShoppingApp.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> employees {  get; set; }
        IRepository<Transaction> transaction { get; set; }
        IRepository<EmpTransaction> employeeTransaction { get; set; }
        int commitChangers();
    }
}
