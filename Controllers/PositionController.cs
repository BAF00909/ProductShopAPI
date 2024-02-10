using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Models;
using ProductShop.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly ILogger<PositionController> _logger;
        private readonly IMapper _mapper;
        private readonly IPositionRepository _repository;
        public PositionController(ILogger<PositionController> logger, IMapper mapper, IPositionRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        // GET: api/<PositionConteroller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionDto>>> Get()
        {
            var positionsFromContext = await _repository.GetPositionsAsync();
            return Ok(_mapper.Map<IEnumerable<PositionDto>>(positionsFromContext));
        }

        // GET api/<PositionConteroller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionDto>> Get(int id)
        {
            var position = await _repository.GetPositionByIdAsync(id);
            if (position == null)
            {
                return NotFound("Должность не найдена");
            }
            return Ok(_mapper.Map<PositionDto>(position));
        }

        // POST api/<PositionConteroller>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PositionCreateDto position)
        {
            var newPosition = _mapper.Map<Entities.Position>(position);
            await _repository.AddPositionAsync(newPosition);
            if (!await _repository.SaveChangeAsync())
            {
                _logger.LogInformation("Должность не добавлена");
                return BadRequest();
            }
            return Ok("Должность добавлена");
        }

        // PUT api/<PositionConteroller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PositionDto position)
        {
            var currentPosition = await _repository.GetPositionByIdAsync(position.Id);
            if (currentPosition == null)
            {
                return NotFound("Должность не найдена");
            }
            _mapper.Map(position, currentPosition);
            await _repository.SaveChangeAsync();
            return Ok(new { message = "Должность обновлена" });
        }

        // DELETE api/<PositionConteroller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<PositionDto>>> Delete(int id)
        {
            var position = await _repository.GetPositionByIdAsync(id);
            if(position == null)
            {
                return NotFound("Должность не найдена");
            }
            await _repository.DeletePositionAsync(position);
            await _repository.SaveChangeAsync();
            var positions = await _repository.GetPositionsAsync();
            return Ok(_mapper.Map<IEnumerable<PositionDto>>(positions));
        }
    }
}
