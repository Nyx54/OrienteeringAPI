using OrienteeringModels.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrienteeringAPI.Repositories.Base
{
    public interface IUserRepository
    {
        Task<List<OrienteeringUser>> GetAll();
    }
}
