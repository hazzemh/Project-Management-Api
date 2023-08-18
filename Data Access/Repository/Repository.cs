using Data_Access.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDBContext context;
        private readonly DbSet<T> dbSet;
        public Repository(AppDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }
        public IEnumerable<T> GetList(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.ToList();
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public List<T> GetAllWithPagination(int pageNo, int pageSize, Expression<Func<T, bool>> filter)
        {
            int startIndex = (pageNo - 1) * pageSize;

            List<T> values = dbSet.Skip(startIndex).Take(pageSize).Where(filter).ToList();

            return values;
        }
        public T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public void Add(T entity)
        {
            context.Add(entity);
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
        public void Remove(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public void Remove(int id)
        {
            T obj = dbSet.Find(id);
            dbSet.Remove(obj);
            context.SaveChanges();
        }
    }
}
