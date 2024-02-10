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
    public class OverdueProductsController : ControllerBase
    {
        private readonly ILogger<OverdueProductsController> _logger;
        private readonly IMapper _mapper;
        private readonly IOverdueProductRepository _repository;
        public OverdueProductsController(ILogger<OverdueProductsController> logger, IMapper mapper, IOverdueProductRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // GET: api/<OverdueProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OverdueProductDto>>> Get()
        {
            var products = await _repository.GetOverdueProductsAsync();
            return Ok(_mapper.Map<IEnumerable<OverdueProductDto>>(products));
        }

        // GET api/<OverdueProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OverdueProductDto>> Get(int id)
        {
            var product = await _repository.GetOverdueProductByIdAsync(id);
            if(product == null)
            {
                return NotFound("Продукт не найден");
            }
            return Ok(_mapper.Map<OverdueProductDto>(product));
        }

        // POST api/<OverdueProductsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OverdueProductCreateDto product)
        {
            var newOverdueProduct = _mapper.Map<OverdueProduct>(product);
            await _repository.AddOverdueProductAsync(newOverdueProduct);
            if(!await _repository.SaveChangeAsync())
            {
                return BadRequest();
            }
            return Ok("Товар успешно списан");
        }

        // PUT api/<OverdueProductsController>/5
        [HttpPut]
        public async Task<ActionResult<OverdueProductDto>> Put([FromBody] OverdueProductUpdateDto product)
        {
            var currentProduct = await _repository.GetOverdueProductByIdAsync(product.Id);
            if(currentProduct == null)
            {
                return NotFound("Продукт не найден");
            }
            _mapper.Map(product, currentProduct);
            await _repository.SaveChangeAsync();
            return Ok(_mapper.Map<OverdueProductDto>(product));
        }

        // DELETE api/<OverdueProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _repository.GetOverdueProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Продукт не найден");
            }
            await _repository.DeleteOverdueProductAsync(product);
            await _repository.SaveChangeAsync();
            return Ok(new { message = "Продукт удален"});
        }
    }
}
