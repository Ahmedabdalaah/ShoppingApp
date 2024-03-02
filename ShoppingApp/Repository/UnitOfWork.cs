using ShoppingApp.Areas.Peport.Models;
using ShoppingApp.Data;
using ShoppingApp.Repository.Base;

namespace ShoppingApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            employees = new MainRepository<Employee>(_context);
            transaction = new MainRepository<Transaction>(_context);
            employeeTransaction = new MainRepository<EmpTransaction>(_context);
        }
        private readonly AppDBContext _context;

        public IRepository<Employee> employees { get; set; }
        public IRepository<Transaction> transaction { get; set; }
        public IRepository<EmpTransaction> employeeTransaction { get; set; }
        public int commitChangers()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
