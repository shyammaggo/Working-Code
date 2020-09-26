using CRUD.API.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.BusinessObjects
{
   public interface IEmployeeBO
    {
        Task<IEnumerable<Employee>> GetAllEmployeess();
        Task<Employee> GetById(int id);
        Employee Add(Employee item);
        Task Update(Employee item);
        Task Remove(int id);
    }
}
