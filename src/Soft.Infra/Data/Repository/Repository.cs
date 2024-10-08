﻿using Soft.Bussiness;
using Soft.Bussiness.Core.Data;
using Soft.Bussiness.Models.Books;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        protected readonly DbSet<TEntity> _dbSet;
        protected Repository(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Set<TEntity>();
        }
        public virtual async Task Add(TEntity entity)
        { 
             _dbSet.Add(entity);
             await SaveChanges();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual async Task Update(TEntity entity)
        {
            _applicationDbContext.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }
        public virtual async Task Delete(TEntity entity)
        {
            if (_applicationDbContext.Entry(entity).State == EntityState.Detached)
            {
                // Attach the entity to the context
                _applicationDbContext.Set<TEntity>().Attach(entity);
            }

            // Mark the entity as deleted
            _applicationDbContext.Entry(entity).State = EntityState.Deleted;
            await SaveChanges();
        }

        //public void Dispose()
        //{
        //    _applicationDbContext?.Dispose();
        //}

        public async Task<int> SaveChanges()
        {
             return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
