using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        public IEnumerable<T> GetList(Expression<Func<T, bool>> filter);
        T GetOne(Expression<Func<T, bool>> filter);
        List<T> GetAllWithPagination(int pageNo , int pageSize, Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(int id);
    }
}
