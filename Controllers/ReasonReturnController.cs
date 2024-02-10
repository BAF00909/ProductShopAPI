﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Entities;
using ProductShop.Models;
using ProductShop.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReasonReturnController : ControllerBase
    {
        private readonly ILogger<ReasonReturnController> _logger;
        private readonly IMapper _mapper;
        private readonly IReasonReturnRepository _repository;
        public ReasonReturnController(ILogger<ReasonReturnController> logger, IMapper mapper, IReasonReturnRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // GET: api/<ReasonReturnController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReasonReturnDto>>> Get()
        {
            var reasons = await _repository.GetReasonReturnAsync();
            return Ok(_mapper.Map<IEnumerable<ReasonReturnDto>>(reasons));
        }

        // GET api/<ReasonReturnController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReasonReturnController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ReasonReturCreateDto reason)
        {
            var newReason = _mapper.Map<ReasonReturn>(reason);
            await _repository.AddNewReasonReturn(newReason);
            if(!await _repository.SaveChangeAsync())
            {
                return BadRequest();
            }
            return Ok("Причина возврата добавлена");
        }

        // PUT api/<ReasonReturnController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReasonReturnController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
