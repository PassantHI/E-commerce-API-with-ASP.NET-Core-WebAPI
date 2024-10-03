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
        //public IEnumerable<T> GetAll() 
        //{
        //    return _context.Set<T>().ToList();

        //}

        public T GetBy(Expression<Func<T, bool>>? expression, string[]? includes)
        {
            IQueryable<T> query = _context.Set<T>();

            // Handle includes
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

        //public T GetBy(Expression<Func<T, bool>>? expression, string[]? includes=null)
        //{
        //    IQueryable<T> query = _context.Set<T>();
        //    if (includes != null&&expression!=null)
        //    {
        //        foreach (var include in includes)
        //        {
        //            query = query.Include(include);

        //        }


        //    }

        //    return query.SingleOrDefault(expression);

        //}
        //eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImQxODlkOTgxLTYzOTUtNDIxYS1iODIwLTQyZDllN2E1ZjEyYSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJwYXNzYW50IiwianRpIjoiOTQyNTlhOTEtYmNmNi00NjNhLTkzYzgtMTkyNWU1YjNhNzNmIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXNlciIsImV4cCI6MTcyNzMwNTMyNiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1ODM1MyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMCJ9.RFwRQxXmAAL7J0S_KuJLihQFii79ZZOa6JojTDQOi6s

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
