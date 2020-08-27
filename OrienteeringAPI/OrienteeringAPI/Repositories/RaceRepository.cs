using OrienteeringAPI.Data;
using OrienteeringAPI.Repositories.Base;
using OrienteeringModels.Dtos;

namespace OrienteeringAPI.Repositories
{
    public class RaceRepository : AbstractBaseRepository<OrienteeringRace, OrienteeringAPIContextFactory>
    {

        public RaceRepository(OrienteeringAPIContextFactory factory) : base(factory)
        {

        }
    }
}
