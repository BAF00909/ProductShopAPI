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
    public class ReturnedProductsController : ControllerBase
    {
        private readonly ILogger<ReturnedProductsController> _logger;
        private readonly IMapper _mapper;
        private readonly IReturnedProductRepository _repository;
        public ReturnedProductsController(
            ILogger<ReturnedProductsController> logger,
            IMapper mapper,
            IReturnedProductRepository repository
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // GET: api/<ReturnedProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnedProductDto>>> Get()
        {
            var products = await _repository.GetReturnedProductAsync();
            return Ok(_mapper.Map<IEnumerable<ReturnedProductDto>>(products));
        }

        // GET api/<ReturnedProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnedProductDto>> Get(int id)
        {
            var product = await _repository.GetReturnedProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Возврат не найден");
            }
            return Ok(_mapper.Map<ReturnedProductDto>(product));
        }

        // POST api/<ReturnedProductsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ReturnedProductCreateDto product)
        {
            var newReturnedProduct = _mapper.Map<ReturnedProduct>(product);
            await _repository.AddReturndeProductAsync(newReturnedProduct);
            if(!await _repository.SaveChangeAsync())
            {
                return BadRequest();
            }
            return Ok("Возврат товара оформлен");
        }

        // PUT api/<ReturnedProductsController>/5
        [HttpPut]
        public async Task<ActionResult<ReturnedProductDto>> Put([FromBody] ReturnedProductUpdateDto product)
        {
            var currentProduct = await _repository.GetReturnedProductByIdAsync(product.Id);
            if (currentProduct == null)
            {
                return NotFound("Возврат не найден");
            }
            _mapper.Map(product, currentProduct);
            await _repository.SaveChangeAsync();
            return Ok(_mapper.Map<ReturnedProductDto>(currentProduct));
        }

        // DELETE api/<ReturnedProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _repository.GetReturnedProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Возврат не найден");
            }
            await _repository.DeleteReturnedProductAsync(product);
            await _repository.SaveChangeAsync();
            return Ok(new { message = "Возврат удален" });
        }
    }
}
