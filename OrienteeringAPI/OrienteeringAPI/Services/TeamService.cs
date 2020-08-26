using OrienteeringAPI.Repositories;
using OrienteeringAPI.Services.Base;
using OrienteeringModels.Dtos;

namespace OrienteeringAPI.Services
{
    public class TeamService : AbstractBaseService<TeamRepository, OrienteeringTeam>
    {

        public TeamService(TeamRepository repository) : base(repository)
        {
        }
    }
}
