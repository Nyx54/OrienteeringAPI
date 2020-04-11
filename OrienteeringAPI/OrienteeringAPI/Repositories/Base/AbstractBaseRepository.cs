using OrienteeringAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringAPI.Repositories.Base
{
    public abstract class AbstractBaseRepository<TEntity, TFactory> : IRepository<TEntity>
      where TEntity : class
      where TFactory : OrienteeringAPIContextFactory
    {
        protected OrienteeringAPIContext context;
        protected readonly OrienteeringAPIContextFactory _factory;

        protected const string _GetAllEndPoint = "GetAll";
        protected const string _GetByKeysEndPoint = "Get";
        protected const string _AddEndPoint = "POST";
        protected const string _PutEndPoint = "PUT";
        protected const string _CustomDataType = "MCentreDto";

        public AbstractBaseRepository(TFactory factory)
        {
            _factory = factory;
        }

        public Task<List<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Get(long i)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
