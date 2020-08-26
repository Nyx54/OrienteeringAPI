﻿using Microsoft.AspNetCore.Mvc;
using OrienteeringAPI.Controllers.Base;
using OrienteeringAPI.Repositories.Base;
using OrienteeringAPI.Services;
using OrienteeringModels.Dtos;

namespace OrienteeringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : AbstractBaseController<OrienteeringLeague, LeagueService>
    {
        public LeagueController(LeagueService service, ILogRepository logRequestRepository) : base(service, logRequestRepository)
        {
        }
    }
}
