using OrienteeringAPI.Data;
using OrienteeringAPI.Repositories.Base;
using OrienteeringModels.Dtos;

namespace OrienteeringAPI.Repositories
{
    public class TeamRepository : AbstractBaseRepository<OrienteeringTeam, OrienteeringAPIContextFactory>
    {

        public TeamRepository(OrienteeringAPIContextFactory factory) : base(factory)
        {

        }
    }
}
