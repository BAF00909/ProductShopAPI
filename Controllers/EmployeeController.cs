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
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _repository;
        public EmployeeController(ILogger<EmployeeController> logger, IMapper mapper, IEmployeeRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        /// <summary>
        /// Получение списка сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.EmployeeDto>>> Get()
        {
            var employees = await _repository.GetEmployeeAsync();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<Models.EmployeeDto>>(employees));
        }

        /// <summary>
        /// Получение сотрудника по его id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var res = await _repository.GetEmployeeByIdAsync(id);
            if(res == null)
            {
                return NotFound("Сотрудник не найден");
            }
            return Ok(_mapper.Map<EmployeeDto>(res));
        }

        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="employee">данные сотрудника</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeeCreateDto employee)
        {
            var newEmployee = _mapper.Map<Entities.Employee>(employee);
            await _repository.AddEmployeeAsync(newEmployee);
            if(await _repository.SaveChangeAsync())
            {
                return Ok("Сотрудник добавлен");
            }
            return BadRequest();
        }

        /// <summary>
        /// Изменение существующего сотрудника
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<EmployeeDto>> Put([FromBody] EmployeeUpdateDto employee)
        {
            var current = await _repository.GetEmployeeByIdAsync(employee.Id);
            if(current == null)
            {
                return NotFound("Сотрудник не найден");
            }
            _mapper.Map(employee, current);
            if(!await _repository.SaveChangeAsync())
            {
                return BadRequest();
            }
            return NoContent();
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id">id сотрудника</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id);
            if(employee == null)
            {
                return NotFound("Сотрудник не найден");
            }
            await _repository.EmployeeDeleteAsync(employee);
            if(!await _repository.SaveChangeAsync())
            {
                return BadRequest();
            }
            return Ok(new { message = "Сотрудник удален"});
        }
    }
}
