using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrienteeringAPI.Errors;
using OrienteeringAPI.Repositories.Base;
using OrienteeringAPI.Services.Base;
using OrienteeringModels.Dtos.Interfaces;
using System.Collections.Generic;
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
            var log = await _logRequestRepository.Add(LogApiGenerator.CreateRequestLog(Request));
            var result = await service.GetAll();
            await _logRequestRepository.Update(LogApiGenerator.UpdateResponseLog(ref log, result));
            return result;
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(long id)
        {
            var log = await _logRequestRepository.Add(LogApiGenerator.CreateRequestLog(Request));
            var entity = await service.Get(id);
            if (entity == null)
            {
                return NotFound();
            }
            await _logRequestRepository.Update(LogApiGenerator.UpdateResponseLog(ref log, entity));
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
    }
}
