using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WorkSync.Application.DTOs;
using WorkSync.Application.Interfaces;

namespace WorkSync.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
[HttpGet]   
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployeesAsync()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeByIdAsync(Guid id)
        {
           var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee ==null)
            {
                return NotFound("employee ID not found.");
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            try
            {
                var employee = await _employeeService.CreateEmployeeAsync(createEmployeeDto);

                return Ok(employee);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployeeAsync(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var resultId = await _employeeService.GetEmployeeByIdAsync(id);

             if(resultId==null ||resultId.Id == null)
            {
                return NotFound("employee ID not found.");
            }
            var employee = await _employeeService.UpdateEmployeeAsync(id, updateEmployeeDto);
            return Ok(employee);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteEmployeeAsync(Guid id)
        {
            var resultId = await _employeeService.GetEmployeeByIdAsync(id);

            if (resultId == null || resultId.Id == null)
            {
                return NotFound("employee ID not found.");
            }
            var result = await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
