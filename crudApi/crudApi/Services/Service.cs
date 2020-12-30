using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using crudApi.Interfaces;
using crudApi.Common;

namespace crudApi.Services
{
    public class Service<TEntity, TContext, TRepositoy> : IService<TEntity>
        where TEntity : class, IEntity
        where TRepositoy : class, IRepository<TEntity>
        where TContext : DbContext
    {
        public readonly TContext context;
        public readonly TRepositoy baseRepository;

        public Service(TContext context, TRepositoy repositoy)
        {
            this.context = context;
            this.baseRepository = repositoy;
        }

        // Create entity
        public virtual TEntity Add(TEntity entity)
        {
            return baseRepository.Add(entity);
        }

        // Read entity by Id
        public virtual TEntity Get(int id)
        {
            return baseRepository.Get(id);
        }

        // Read all entities
        public virtual List<TEntity> GetAll()
        {
            return baseRepository.GetAll();
        }

        // Update entity
        public virtual TEntity Update(TEntity entity)
        {
            return baseRepository.Update(entity);
        }

        // Delete entity
        public virtual TEntity Delete(int id)
        {
            return baseRepository.Delete(id);
        }
        
    }
}
