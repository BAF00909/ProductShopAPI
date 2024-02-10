using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Models;
using ProductShop.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupsController : ControllerBase
    {
        private readonly ILogger<ProductGroupsController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductGroupRepository _repository;
        public ProductGroupsController(ILogger<ProductGroupsController> logger, IMapper mapper, IProductGroupRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // GET: api/<ProductGroupsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ProductGroupDto>>> Get()
        {
            var groups = await _repository.GetProductGroups();
            return Ok(_mapper.Map<IEnumerable<ProductGroupDto>>(groups));
        }

        // GET api/<ProductGroupsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroupDto>> Get(int id)
        {
            var group = await _repository.GetProductGroupByIdAsync(id);
            if (group == null)
            {
                return NotFound("Категория не найдена");
            }
            return Ok(_mapper.Map<ProductGroupDto>(group));
        }

        // POST api/<ProductGroupsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductGroupCreateDto productGroup)
        {
            var newProductGrop = _mapper.Map<Entities.ProductGroup>(productGroup);
            await _repository.AddNewProductGroupAsync(newProductGrop);
            if (!await _repository.SaveChangeAsync())
            {
                return BadRequest();
            }
            return Ok("Группа товара добавлена");
        }

        // PUT api/<ProductGroupsController>/5
        [HttpPut]
        public async Task<ActionResult<ProductGroupDto>> Put([FromBody] ProductGroupDto group)
        {
            var currentGroup = await _repository.GetProductGroupByIdAsync(group.Id);
            if (currentGroup == null)
            {
                return NotFound("Категория не найдена");
            }
            _mapper.Map(group, currentGroup);
            await _repository.SaveChangeAsync();
            return Ok(new { message = "Категория обновлена" });
        }

        // DELETE api/<ProductGroupsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var groupDelete = await _repository.GetProductGroupByIdAsync(id);
            if (groupDelete == null)
            {
                return NotFound("Категория не найдена");
            }
            await _repository.DeleteGroupAsync(groupDelete);
            await _repository.SaveChangeAsync();
            return Ok(new { message = "Категория удалена"});
        }
    }
}
