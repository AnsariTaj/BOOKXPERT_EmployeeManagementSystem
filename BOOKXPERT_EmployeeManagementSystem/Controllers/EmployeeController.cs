using BOOKXPERT_EmployeeManagementSystem.BusinessLogicLayer.IServices;
using BOOKXPERT_EmployeeManagementSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKXPERT_EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet("states")]
        public async Task<IActionResult> GetStates()
        {
            var states = await _employeeRepository.GetStatesAsync();
            if (states == null)
            {
                return NotFound();
            }
            var response = new
            {
                Success = true,
                Message = "Student details got seccessfully",
                Data = states
            };
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            if (employees == null)
            {
                return NotFound();
            }
            var response = new
            {
                Success = true,
                Message = "Student details got seccessfully",
                Data = employees
            };
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            var response = new
            {
                Success = true,
                Message = "Student details got seccessfully",
                Data = employee
            };
            return Ok(response);
        }
        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeModel employee)
        {
            await _employeeRepository.CreateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeModel employee)
        {
            if (id != employee.EmployeeId)
                return BadRequest();

            await _employeeRepository.UpdateEmployeeAsync(employee);
            return Ok(employee);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }

}
