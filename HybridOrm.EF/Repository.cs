using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HybridOrm.Model;

namespace HybridOrm.Repository.EF
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbSet<T> _dbSet;

        public IDbConnection Connection
        {
            get { throw new NotImplementedException(); }
        }

        public Repository(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T FindById(int id)
        {
            return _dbSet.Single(t => t.Id == id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }
    }
}