using OrienteeringAPI.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringAPI.Services.Base
{
    public abstract class AbstractBaseService<TRepository, TEntity> : IService<TEntity>
         where TRepository : IRepository<TEntity>
         where TEntity : class
    {
        protected readonly TRepository repository;

        public AbstractBaseService(TRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await repository.Add(entity);
            return entity;
        }

        public async Task<TEntity> Delete(long id)
        {
            var entity = await repository.Delete(id);
            return entity;
        }

        public async Task<TEntity> Get(long id)
        {
            var entity = await repository.Get(id);
            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            await repository.Update(entity);
            return entity;
        }
    }
}
