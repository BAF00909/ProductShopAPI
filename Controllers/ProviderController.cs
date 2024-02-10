using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Entities;
using ProductShop.Models;
using ProductShop.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly ILogger<ProviderController> _logger;
        private readonly IProviderRepository _repository;
        private readonly IMapper _mapper;
        public ProviderController(ILogger<ProviderController> logger, IMapper mapper, IProviderRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // GET: api/<ProviderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProviderDto>>> Get()
        {
            var providers = await _repository.GetProvidersAsync();
            return Ok(_mapper.Map<IEnumerable<ProviderDto>>(providers));
        }

        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProviderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProviderCreateDto provider)
        {
            var newProvider = _mapper.Map<Provider>(provider);
            await _repository.AddNewProviderAsync(newProvider);
            if(!await _repository.SaveChangeAsync())
            {
                return BadRequest();
            }
            return Ok("Поставщик добавлен");
        }

        // PUT api/<ProviderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProviderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
