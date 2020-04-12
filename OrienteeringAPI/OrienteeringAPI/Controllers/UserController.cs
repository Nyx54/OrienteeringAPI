using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrienteeringAPI.Controllers.Base;
using OrienteeringAPI.Errors;
using OrienteeringAPI.Repositories.Base;
using OrienteeringAPI.Services;
using OrienteeringModels.Dtos;
using OrienteeringModels.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AbstractBaseController<OrienteeringUser, UserService>
    {
        public UserController(UserService service, ILogRepository logRequestRepository) : base(service, logRequestRepository)
        {
        }

        //// GET: api/[controller]/Login
        //// On authorize ce endpoint pour pouvoir renvoyer le token
        [AllowAnonymous]
        [HttpPost("/Login")]
        [ProducesResponseType(200, Type = typeof(LoginResultModel))]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<LoginResultModel>> LoginRequest([FromBody] LoginRequestModel loginRequestModel)
        {
            var log = await _logRequestRepository.Add(CreateRequestLog(new LoginRequestModel()
            {
                Login = loginRequestModel.Login,
                Password = (string.IsNullOrEmpty(loginRequestModel.Password)) ? string.Empty : "XXXXX"
            }));
            try
            {
                if (string.IsNullOrEmpty(loginRequestModel.Login) ||
                    string.IsNullOrEmpty(loginRequestModel.Password))
                {
                    var error = GenerateError.BadRequestError(loginRequestModel.GetType().GetProperties().ToList().Where(p => p.GetValue(loginRequestModel) == null).Select(p => p.Name).ToList());
                    await _logRequestRepository.Update(UpdateResponseLog(ref log, error));
                    return BadRequest(error);
                }
                var loginResult = await base.service.LoginRequest(loginRequestModel);
                if (loginResult == null)
                {
                    var error = GenerateError.ObjectNotFound<OrienteeringUser>();
                    await _logRequestRepository.Update(UpdateResponseLog(ref log, error));
                    return NotFound(error);
                }
                if (string.IsNullOrEmpty(loginResult.Token))
                {
                    var error = GenerateError.LoginError();
                    await _logRequestRepository.Update(UpdateResponseLog(ref log, error));
                    return Unauthorized(error);
                }
                await _logRequestRepository.Update(UpdateResponseLog(ref log, loginResult));
                return loginResult;
            }
            catch (Exception e)
            {
                var error = GenerateError.UnexpectedError();
                await _logRequestRepository.Update(UpdateResponseLog(ref log, error, e?.Message));
                return StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }
    }
}
}
