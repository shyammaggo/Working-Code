using CRUD.API.Contracts;
using CRUD.API.Data;
using CRUD.API.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace CRUD.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }
        public Employee Add(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChangesAsync();
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployeess()
        {
            return _context.Employee.ToList();
        }
        public  void Remove(int id)
        {
            var existingEmp=_context.Employee.Find(id);
            if(existingEmp==null)
            {
                return;
            }
           Employee emp= _context.Employee.Find(id);
            _context.Remove(emp);
            _context.SaveChanges();
       }
        public Employee GetById(int id)
        {
            return _context.Employee.Find(id);
        }

        public Employee Update(Employee emp)
        {
            _context.Entry<Employee>(emp).State = EntityState.Modified;
            _context.SaveChanges();
            return emp;
        }
    }
}
