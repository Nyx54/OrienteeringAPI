using Microsoft.AspNetCore.Mvc;
using OrienteeringAPI.Controllers.Base;
using OrienteeringAPI.Repositories.Base;
using OrienteeringAPI.Services;
using OrienteeringModels.Dtos;

namespace OrienteeringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : AbstractBaseController<OrienteeringTeam, TeamService>
    {
        public TeamController(TeamService service, ILogRepository logRequestRepository) : base(service, logRequestRepository)
        {
        }
    }
}
