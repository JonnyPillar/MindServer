﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MindServer.Services.Repository.Interfaces;

namespace MindServer.Services.Repository.DataLayer
{
    public class EntityFrameworkRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private DbContext _dbContext;

        protected DbContext DbContext
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>();
        }

        public TEntity Get(TKey id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> GetRange(int quantity)
        {
            IQueryable<TEntity> temp = _dbContext.Set<TEntity>();
            if (quantity > temp.Count()) return temp;
            return temp.Take(quantity);
        }

        public IEnumerable<TEntity> GetRange(int page, int quantity)
        {
            var startIndex = page*quantity;
            return _dbContext.Set<TEntity>().Skip(startIndex).Take(quantity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Single(predicate);
        }

        public void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Update(TKey key, TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            var currentEntity = DbContext.Set<TEntity>().Find(key);
            DbContext.Entry(currentEntity).CurrentValues.SetValues(entity);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            var result = _dbContext.Set<TEntity>().Where(predicate);
            return result.Any();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(int id)
        {
            var entityToDelete = _dbContext.Set<TEntity>().Find(id);
            if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbContext.Set<TEntity>().Attach(entityToDelete);
            }
            DbContext.Set<TEntity>().Remove(entityToDelete);
        }
    }
}