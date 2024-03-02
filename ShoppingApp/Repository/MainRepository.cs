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
    }
}
