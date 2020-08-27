using OrienteeringAPI.Repositories;
using OrienteeringAPI.Services.Base;
using OrienteeringModels.Dtos;

namespace OrienteeringAPI.Services
{
    public class RaceService : AbstractBaseService<RaceRepository, OrienteeringRace>
    {

        public RaceService(RaceRepository repository) : base(repository)
        {
        }
    }
}
