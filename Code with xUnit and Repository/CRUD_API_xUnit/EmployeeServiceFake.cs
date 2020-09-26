using CRUD.API.Contracts;
using CRUD.API.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.API_xUnit
{
    public class EmployeeServiceFake : IEmployeeService
    {
        private readonly List<Employee> _employeeDB;
        public EmployeeServiceFake()
        {
            _employeeDB = new List<Employee>()
            {
                new Employee(){Id=100,Name="John",Description="Developer"},
                new Employee(){Id=101,Name="Jim",Description="Sr. Developer"},
                new Employee(){Id=102,Name="Jack",Description="Tech Lead"},
                new Employee(){Id=103,Name="Jin",Description="Sr. Developer"},
                new Employee(){Id=104,Name="Jolly",Description="Tech Lead"}
            };
        }
        public IEnumerable<Employee> GetAllEmployeess()
        {
            return _employeeDB;
        }

        public Employee Add(Employee newItem)
        {
            Random rnd = new Random();
            newItem.Id = rnd.Next(1, 1000);
            _employeeDB.Add(newItem);
            return newItem;
        }

        public Employee GetById(int id)
        {
            return _employeeDB.Where(a => a.Id == id)
                 .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existing = _employeeDB.First(a => a.Id == id);
            _employeeDB.Remove(existing);
        }

        public Employee Update(Employee employee)
        {
            return employee;
        }
    }
}
