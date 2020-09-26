using CRUD.API.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.API.Contracts
{
   public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployeess();
        Employee Add(Employee emp);
        Employee GetById(int id);
        void Remove(int id);
        Employee Update(Employee emp);
    }
}
