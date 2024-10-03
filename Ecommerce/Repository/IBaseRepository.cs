using System.Linq.Expressions;

namespace Ecommerce.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);

        T GetBy(Expression<Func<T,bool>> expression=null,string[] include=null);
        IEnumerable<T> GetAllBy(Expression<Func<T, bool>> expression, string? include = null);
        IEnumerable<T> GetAll(string? include = null);
        public T GetByIdandUserId(Expression<Func<T, bool>> expression, string include);
        void Add(T entity);

        void Update(T entity);

        void DeleteById(int id);

        



    }
}
