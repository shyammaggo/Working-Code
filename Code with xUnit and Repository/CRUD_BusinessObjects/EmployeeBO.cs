using CRUD.API.Domain;
using CRUD.API.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BusinessObjects
{
    public class EmployeeBO : IEmployeeBO
    {
        IEmployeeRepository _repository;
        public EmployeeBO(IEmployeeRepository repository)
        {
            _repository = repository;
        }
       
        public    Employee Add(Employee emp)
        {
              _repository.Add(emp);
            return emp;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeess()
        {
            return await _repository.GetAllEmployeess();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Remove(int id)
        {
            await _repository.Remove(id);
        }

        public async Task Update(Employee emp)
        {
            await _repository.Update(emp);
        }
    }
}
