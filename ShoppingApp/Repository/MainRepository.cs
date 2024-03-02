using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data;
using ShoppingApp.Repository.Base;

namespace ShoppingApp.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(AppDBContext context)
        {
            this.context = context;
        }
        private AppDBContext context;

        public T FindById(int? id)
        {
            return context.Set<T>().Find(id);
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public void DeleteCat(T cat)
        {
            context.Set<T>().Remove(cat);
            context.SaveChanges();
        }

        public void UpdateCat(T cat)
        {
            context.Set<T>().Update(cat);
            context.SaveChanges();
        }

        public void AddCat(T cat)
        {
            context.Set<T>().Add(cat);
            context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return await query.ToListAsync();
        }
    }
}
