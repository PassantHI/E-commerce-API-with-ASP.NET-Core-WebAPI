using Ecommerce.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Ecommerce.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDBContext _context;

        public BaseRepository(ApplicationDBContext context)
        {
            _context = context;
        }


        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            
        }

        public void DeleteById(int id)
        {
            T exist=_context.Set<T>().Find(id);
            if (exist != null)
            { 
                _context.Set<T>().Remove(exist);
            }
        }

        public IEnumerable<T> GetAllBy(Expression<Func<T, bool>> expression, string? include = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (include != null)
            {
                query= query.Include(include);
            }
            return query.Where(expression).ToList();
        }

        public IEnumerable<T> GetAll(string? include = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (include != null)
            {
                query = query.Include(include);

            }
            return query.ToList();
        }
        

        public T GetBy(Expression<Func<T, bool>>? expression, string[]? includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            

            return query.FirstOrDefault(expression);
        }
        public T GetByIdandUserId(Expression<Func<T, bool>> expression, string include)
        {
            return _context.Set<T>().Include(include).FirstOrDefault(expression);

        }

       
        public T GetById(int id)
        {
            var exist= _context.Set<T>().Find(id);
            if(exist != null) { return exist; }

            return null;
            
        }

        public void Update(T entity)
        {
            _context.Update(entity);

        }
    }
}
