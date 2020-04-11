using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrienteeringAPI.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(long i);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(long id);
    }
}
