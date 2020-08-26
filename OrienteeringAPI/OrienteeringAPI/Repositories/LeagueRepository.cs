using OrienteeringAPI.Data;
using OrienteeringAPI.Repositories.Base;
using OrienteeringModels.Dtos;

namespace OrienteeringAPI.Repositories
{
    public class LeagueRepository : AbstractBaseRepository<OrienteeringLeague, OrienteeringAPIContextFactory>
    {

        public LeagueRepository(OrienteeringAPIContextFactory factory) : base(factory)
        {

        }
    }
}
