using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrienteeringAPI.Services.Base
{
    public interface IService<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(long id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(long id);
    }
}
