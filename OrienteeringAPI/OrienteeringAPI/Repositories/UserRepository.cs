using OrienteeringAPI.Data;
using OrienteeringAPI.Repositories.Base;
using OrienteeringModels.Dtos;

namespace OrienteeringAPI.Repositories
{
    public class UserRepository : AbstractBaseRepository<OrienteeringUser, OrienteeringAPIContextFactory>
    {

        public UserRepository(OrienteeringAPIContextFactory factory) : base(factory)
        {

        }
    }
}
