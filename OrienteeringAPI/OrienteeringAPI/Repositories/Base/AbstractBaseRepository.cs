using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrienteeringAPI.Data;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace OrienteeringAPI.Repositories.Base
{
    public abstract class AbstractBaseRepository<TEntity, TFactory> : IRepository<TEntity>
      where TEntity : class
      where TFactory : OrienteeringAPIContextFactory
    {
        protected OrienteeringAPIContext context;
        protected readonly OrienteeringAPIContextFactory _factory;

        public AbstractBaseRepository(TFactory factory)
        {
            _factory = factory;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            this.context = _factory.CreateDbContext();
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(long id)
        {
            this.context = _factory.CreateDbContext();
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(long id)
        {
            this.context = _factory.CreateDbContext();
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            this.context = _factory.CreateDbContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            this.context = _factory.CreateDbContext();
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
