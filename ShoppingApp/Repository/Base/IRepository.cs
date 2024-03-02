namespace ShoppingApp.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T FindById(int? id);
        IEnumerable<T> FindAll();
        Task<IEnumerable<T>> GetAllAsync(params string[] agers);
        void DeleteCat(T cat);
        void UpdateCat(T cat);
        void AddCat(T cat);
    }
}
