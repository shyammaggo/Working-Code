using CRUD.API.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.API.Repositories
{
  public  interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeess();
        Task<Employee> GetById(int id);
        Task<Employee> Add(Employee item);
        Task Update(Employee item);
        Task Remove(int id);
    }
}
