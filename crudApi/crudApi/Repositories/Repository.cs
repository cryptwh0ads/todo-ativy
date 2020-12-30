using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using crudApi.Common;
using crudApi.Interfaces;
using System.Linq;

namespace crudApi.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext 
    {
        public readonly TContext context;

        public Repository (TContext context)
        {
            this.context = context;
        }

        // Create entity
        public virtual TEntity Add (TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();

            return entity;
        }

        // Read entity by Id
        public virtual TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        // Read all entities
        public virtual List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        // Update Entity
        public virtual TEntity Update(TEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            var local = context.Set<TEntity>()
                .Local
                .FirstOrDefault(entry => entity.Id.Equals(entity.Id));

            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }

            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity;
        }

        // Delete entity
        public virtual TEntity Delete(int id)
        {
            var entity = context.Set<TEntity>().Find(id);

            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();

            return entity;
        }

        public virtual void ReverseUpdateState(TEntity entity)
        {
            var local = context.Set<TEntity>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(entity.Id));

            if (local != null)
                context.Entry(local).State = EntityState.Detached;
        }

    }
}
