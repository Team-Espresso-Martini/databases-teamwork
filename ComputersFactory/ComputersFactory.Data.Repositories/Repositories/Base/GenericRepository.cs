using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using ComputersFactory.Data.Repositories.Repositories.Contracts;

namespace ComputersFactory.Data.Repositories.Repositories.Base
{
    public class GenericRepository<TEntity>
        : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext entityContext;

        public GenericRepository(DbContext entityContext)
        {
            if (entityContext == null)
            {
                throw new ArgumentNullException(nameof(entityContext));
            }

            this.entityContext = entityContext;
        }

        protected virtual DbContext Context
        {
            get
            {
                return this.entityContext;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            var entities = this.entityContext.Set<TEntity>().ToList();
            return entities;
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.entityContext.Set<TEntity>().Add(entity);
        }
    }
}
