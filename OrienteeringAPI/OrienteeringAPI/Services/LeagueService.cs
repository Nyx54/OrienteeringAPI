using OrienteeringAPI.Repositories;
using OrienteeringAPI.Services.Base;
using OrienteeringModels.Dtos;

namespace OrienteeringAPI.Services
{
    public class LeagueService : AbstractBaseService<LeagueRepository, OrienteeringLeague>
    {

        public LeagueService(LeagueRepository repository) : base(repository)
        {
        }
    }
}
