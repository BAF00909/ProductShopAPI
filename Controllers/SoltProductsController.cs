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
    public class SoltProductsController : ControllerBase
    {
        private readonly ILogger<SoltProductsController> _logger;
        private readonly IMapper _mapper;
        private readonly ISoltProductRepository _repository;
        public SoltProductsController(ILogger<SoltProductsController> logger, IMapper mapper, ISoltProductRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // GET: api/<SoltProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoltProductDto>>> Get()
        {
            var soltProducts = await _repository.GetSoltProductsAsync();
            return Ok(_mapper.Map<IEnumerable<SoltProductDto>>(soltProducts));
        }

        // GET api/<SoltProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SoltProductsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SoltProductCreateDto product)
        {
            var newSoltProduct = _mapper.Map<SoltProduct>(product);
            await _repository.AddSoltProductAsync(newSoltProduct);
            if(!await _repository.SaveChangeAsync())
            {
                return BadRequest();
            }
            return Ok("Продукт продан");
        }

        // PUT api/<SoltProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SoltProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
