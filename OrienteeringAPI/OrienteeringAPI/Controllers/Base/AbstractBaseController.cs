using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrienteeringAPI.Errors;
using OrienteeringAPI.Repositories.Base;
using OrienteeringAPI.Services.Base;
using OrienteeringModels.Dtos;
using OrienteeringModels.Dtos.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrienteeringAPI.Controllers.Base
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AbstractBaseController<TEntity, TService> : ControllerBase
        where TEntity : class, IEntity
        where TService : IService<TEntity>
    {
        protected readonly TService service;
        protected readonly ILogRepository _logRequestRepository;

        public AbstractBaseController(TService service, ILogRepository logRequestRepository)
        {
            this.service = service;
            this._logRequestRepository = logRequestRepository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            var log = await _logRequestRepository.Add(CreateRequestLog());
            var result = await service.GetAll();
            await _logRequestRepository.Update(UpdateResponseLog(ref log, result));
            return result;
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(long id)
        {
            var log = await _logRequestRepository.Add(CreateRequestLog());
            var entity = await service.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            await _logRequestRepository.Update(UpdateResponseLog(ref log, entity));
            return entity;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await service.Update(entity);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            var addedEntity = await service.Add(entity);
            return Created("Get", addedEntity);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(long id)
        {
            var entity = await service.Delete(id);
            if (entity == null)
            {
                return NotFound(GenerateError.ObjectNotFound<TEntity>());
            }
            return entity;
        }

        protected LogAPI UpdateResponseLog(ref LogAPI log, object responseObject, string exceptionMessage = null)
        {
            StringBuilder ResponseBody = new StringBuilder($"{{{Environment.NewLine}");

            var objectType = responseObject.GetType();
            if (responseObject is IList && objectType.IsGenericType && objectType.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
            {
                Type elementType = objectType.GenericTypeArguments.Single();
                var count = ((IList)responseObject).Count;
                ResponseBody.Append($"List of {elementType}{Environment.NewLine}");
                ResponseBody.Append($"Number of elements: {count}");
                ResponseBody.Append($"{Environment.NewLine}}}");
            }
            else
            {
                objectType.GetProperties().ToList().ForEach(p =>
                ResponseBody.Append($"{p.Name}: {p.GetValue(responseObject)}{Environment.NewLine}"));
                ResponseBody.Append($"{Environment.NewLine}}}");
            }

            log.Response = ResponseBody.ToString();
            if (responseObject != null && responseObject is ErrorModel)
            {
                log.StatusCode = ((ErrorModel)responseObject).StatusCode;
            }
            else
            {
                log.StatusCode = StatusCodes.Status200OK;
            }
            log.RespondedOn = DateTime.Now;

            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                log.Exception = exceptionMessage;
            }

            return log;
        }

        protected LogAPI CreateRequestLog(object requestBody = null)
        {
            try
            {
                var log = new LogAPI
                {
                    Path = Request.Path,
                    Method = Request.Method,
                    QueryString = Request.QueryString.ToString()
                };

                if (requestBody != null)
                {
                    StringBuilder listOfProperties = new StringBuilder($"{{{Environment.NewLine}");

                    requestBody.GetType().GetProperties().ToList().ForEach(p =>
                    listOfProperties.Append($"{p.Name}: {p.GetValue(requestBody)}{Environment.NewLine}"));
                    listOfProperties.Append($"{Environment.NewLine}}}");

                    log.Body = listOfProperties.ToString();
                }
                log.RequestedOn = DateTime.Now;
                return log;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
