using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.API.Data;
using CRUD.API.Domain;
using CRUD.API.Contracts;
using CRUD.BusinessObjects;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeContext _context;
        private readonly IEmployeeService _service;
    
        public EmployeesController(IEmployeeService service)
        {
           _service = service;
        }

        // GET: api/Employees
        [HttpGet]
         public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            var items = _service.GetAllEmployeess();
            return Ok(items);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _service.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        } 
        // POST: api/Employees
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult PostEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            employee= _service.Add(employee);
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }
       
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
              // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _service.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            _service.Remove(id);
            return Ok(employee);
        }
        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public    IActionResult   PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            try
            {
                 _service.Update(employee);
            }
            catch (ApplicationException ex)
            {
                if (ex.Message == "Not Found")
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
      
    }
}
