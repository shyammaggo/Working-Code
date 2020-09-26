using CRUD.API.Domain;
using CRUD.API.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.API.EFRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;

        }
        public async Task<Employee> Add(Employee item)
        {
            _context.Employee.Add(item);
           await  _context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeess()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _context.Employee.FirstAsync(item => item.Id == id);
            if (employee == null)
            {
                throw new ApplicationException("Not Found");
            }
            return employee;
        }

        public async Task Remove(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                throw new ApplicationException("Not Found");
            }
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
