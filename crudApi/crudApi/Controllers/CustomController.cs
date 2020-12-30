using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using crudApi.Common;
using crudApi.Interfaces;

namespace crudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CustomController<TEntity, TService> : ControllerBase
        where TEntity : class, IEntity
        where TService : IService<TEntity>
    {
        public readonly TService service;
        public readonly ILogger logger;

        public CustomController(TService _service, ILogger _logger)
        {
            this.service = _service;
            this.logger = _logger;
        }

        // Create entity
        [HttpPost]
        public virtual HttpResponse<TEntity> Post(TEntity entity)
        {
            logger.LogInformation($"{this.GetType().Name} - POST - {entity.ToString()}");

            try
            {
                entity.CreatedAt = DateTime.UtcNow;

                var createdData = service.Add(entity);
                var statusRequest = HttpStatusCode.Created;

                return new HttpResponse<TEntity>
                {
                    IsStatusCodeSuccess = true,
                    statusCode = statusRequest,
                    data = createdData
                };
            }
            catch(Exception e)
            {
                logger.LogError(e.Message);

                return new HttpResponse<TEntity>
                {
                    IsStatusCodeSuccess = false,
                    statusCode = HttpStatusCode.InternalServerError,
                    data = null,
                    ErrorMessage = e.Message
                };
            }
        }

        // Read all entities
        [HttpGet]
        public virtual HttpResponse<List<TEntity>> Get([FromQuery] TEntity query)
        {
            logger.LogInformation($"{this.GetType().Name} - GetAll");
            try
            {
                var dataList = service.GetAll();

                return new HttpResponse<List<TEntity>>
                {
                    IsStatusCodeSuccess = true,
                    statusCode = HttpStatusCode.OK,
                    data = dataList
                };
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return new HttpResponse<List<TEntity>>
                {
                    IsStatusCodeSuccess = false,
                    statusCode = HttpStatusCode.InternalServerError,
                    data = null,
                    ErrorMessage = "Erro ao realizar a requisição"
                };
            }
        }

        // Read entity by Id
        [HttpGet("{id}")]
        public virtual HttpResponse<TEntity> Get(int id)
        {
            logger.LogInformation($"{this.GetType().Name} - Get - {id}");
            try
            {
                var data = service.Get(id);
                var statusRequest = (data == null) ? HttpStatusCode.NotFound : HttpStatusCode.OK;
                var hasError = (statusRequest == HttpStatusCode.OK);

                return new HttpResponse<TEntity>
                {
                    IsStatusCodeSuccess = hasError,
                    statusCode = statusRequest,
                    data = data
                };
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return new HttpResponse<TEntity>
                {
                    IsStatusCodeSuccess = false,
                    statusCode = HttpStatusCode.InternalServerError,
                    data = null,
                    ErrorMessage = "Erro ao realizar a requisição"
                };
            }
        }

        // Update entity
        [HttpPut("{id}")]
        public virtual HttpResponse<TEntity> Put(int id, TEntity entity)
        {
            logger.LogInformation($"{this.GetType().Name} - Put - {id}");
            try
            {
                entity.UpdatedAt = DateTime.UtcNow;

                var updatedData = service.Update(entity);

                var statusRequest = (id != entity.Id) ? HttpStatusCode.BadRequest : HttpStatusCode.OK;
                return new HttpResponse<TEntity>
                {
                    IsStatusCodeSuccess = (statusRequest == HttpStatusCode.OK),
                    statusCode = statusRequest,
                    data = updatedData
                };
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return new HttpResponse<TEntity>
                {
                    IsStatusCodeSuccess = false,
                    statusCode = HttpStatusCode.InternalServerError,
                    data = null,
                    ErrorMessage = e.Message
                };
            }
        }

        // Delete entity
        [HttpDelete("{id}")]
        public virtual HttpResponse<TEntity> Delete(int id)
        {
            logger.LogInformation($"{this.GetType().Name} - Delete - {id}");
            try
            {

                var statusRequest = HttpStatusCode.OK;
                var createdData = service.Delete(id);

                return new HttpResponse<TEntity>
                {
                    IsStatusCodeSuccess = true,
                    statusCode = statusRequest,
                    data = createdData
                };
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return new HttpResponse<TEntity>
                {
                    IsStatusCodeSuccess = false,
                    statusCode = HttpStatusCode.InternalServerError,
                    data = null,
                    ErrorMessage = String.IsNullOrEmpty(e.Message) ? "Erro ao realizar a requisição" : e.Message
                };
            }
        }
    }
}
