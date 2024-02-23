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
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public ProductsController(ILogger<ProductsController> logger, IMapper mapper, IProductRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get(
            [FromQuery] int? id, int? art, string? productName, DateTime? dateIn, int? count, decimal? cost, int? productGroupId, int? supplyId
            )
        {
            var products = await _repository.GetProductsAsync(
                id, art, productName, dateIn, count, cost, productGroupId, supplyId
                );
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Продукт не найден");
            }
            return Ok(_mapper.Map<ProductDto>(product));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductCreateDto product)
        {
            var newProduct = _mapper.Map<Product>(product);
            await _repository.AddProductAsync(newProduct);
            if (!await _repository.SaveChangeAsync())
            {
                return BadRequest();
            }
            return Ok("Товар добавлен");
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<ActionResult<ProductDto>> Put([FromBody] ProductUpdateDto product)
        {
            var currentProduct = await _repository.GetProductByIdAsync(product.Id);
            if (currentProduct == null)
            {
                return NotFound("Продукт не найден");
            }
            _mapper.Map(product, currentProduct);
            await _repository.SaveChangeAsync();
            return Ok(_mapper.Map<ProductDto>(currentProduct));
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Продукт не найден");
            }
            await _repository.DeleteProductAsync(product);
            await _repository.SaveChangeAsync();
            return Ok(new { message = "Продукт удален" });
        }
    }
}
