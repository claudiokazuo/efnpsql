using Api.DataTransferObjects;
using Api.Stores;
using Application.Commands.DocumentType;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Shared.Handlers;
using Shared.Repositories;
using Shared.Stores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/documenttypes")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private IGenericRepository<DocumentType> _repository;
        private IGenericHandler<DocumentTypeCreateCommand> _handler;
        private IMapper _mapper;        
        private IConfiguration _configuration;
        private ICacheStore<DocumentTypeDTO> _cacheStore;
        private ICacheKey<DocumentTypeDTO> _cacheKey;

        public DocumentTypeController(IGenericRepository<DocumentType> repository, 
                                      IGenericHandler<DocumentTypeCreateCommand> handler,
                                      IMapper mapper,
                                      IDistributedCache distributedCache,
                                      IConfiguration configuration)
        {
            _repository = repository;
            _handler = handler;
            _mapper = mapper;            
            _cacheStore = new DistributedCacheStore<DocumentTypeDTO>(distributedCache,
                                    Convert.ToInt32(configuration["RedisSlidingExpirationInSeconds"]),
                                    Convert.ToInt32(configuration["RedisAbsoluteExpirationInSeconds"]));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _cacheKey = new DistributedCacheKey<DocumentTypeDTO>(-1);
            var cachedResult = await _cacheStore.GetDataListAsync(_cacheKey.CacheKey);

            if (cachedResult == null)
            {
                var collection = _repository.GetAll();
                var dto = _mapper.Map<IEnumerable<DocumentTypeDTO>>(collection);
                await _cacheStore.AddDataListAsync(dto, _cacheKey.CacheKey);
                return Ok(dto);
            }
            return Ok(cachedResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            _cacheKey = new DistributedCacheKey<DocumentTypeDTO>(id);
            var cachedResult = await _cacheStore.GetDataAsync(_cacheKey.CacheKey);

            if (cachedResult == null)
            {
                var entity = _repository.SearchById(id);
                var dto = _mapper.Map<DocumentTypeDTO>(entity);
                await _cacheStore.AddDataAsync(dto, _cacheKey.CacheKey);
                return Ok(dto);
            }
            return Ok(cachedResult);            
        }

        [HttpPost]
        public IActionResult Post([FromBody] DocumentTypeCreateCommand command)
        {
            return Ok(_handler.Handle(command));
        }
    }
}
