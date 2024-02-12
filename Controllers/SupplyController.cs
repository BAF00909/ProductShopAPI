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
    public class SupplyController : ControllerBase
    {
        private readonly ILogger<SupplyController> _logger;
        private readonly IMapper _mapper;
        private readonly ISupplyRepository _repository;
        public SupplyController(ILogger<SupplyController> logger, IMapper mapper, ISupplyRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // GET: api/<SupplyController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplyDto>>> Get()
        {
            var supplies = await _repository.GetSuppliesAsync();
            return Ok(_mapper.Map<IEnumerable<SupplyDto>>(supplies));
        }

        // GET api/<SupplyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplyDto>> Get(int id)
        {
            var supply = await _repository.GetsuplyByIdAsync(id);
            if (supply == null)
            {
                return NotFound("Доставка не найдена");
            }
            return Ok(_mapper.Map<SupplyDto>(supply));
        }

        // POST api/<SupplyController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SupplyCreateDto supply)
        {
            var newSupply = _mapper.Map<Supply>(supply);
            await _repository.AddSupplyAsync(newSupply);
            if(!await _repository.SaveChangeAsync())
            {
                return BadRequest();
            }
            return Ok("Поставка добавлена");
        }

        // PUT api/<SupplyController>/5
        [HttpPut]
        public async Task<ActionResult<SupplyDto>> Put([FromBody] SupplyUpdateDto supply)
        {
            var currentSupply = await _repository.GetsuplyByIdAsync(supply.Id);
            if (currentSupply == null)
            {
                return NotFound("Доставка не найдена");
            }
            _mapper.Map(supply, currentSupply);
            await _repository.SaveChangeAsync();
            return Ok(_mapper.Map<SupplyDto>(currentSupply));
        }

        // DELETE api/<SupplyController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var supply = await _repository.GetsuplyByIdAsync(id);
            if (supply == null)
            {
                return NotFound("Доставка не найдена");
            }
            await _repository.DeleteSupplyAsync(supply);
            await _repository.SaveChangeAsync();
            return Ok(new { message = "Доставка удалена" });
        }
    }
}
