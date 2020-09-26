using CRUD.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.API.Data
{
    public class EmployeeDataSeed
    {
        public static async Task SeedAsync(EmployeeContext context)
        {
            if (!context.Employee.Any())
            {
                context.Employee.AddRange(GetPreconfiguredGlossaryTerms());
                await context.SaveChangesAsync();
            }
        }

        static IEnumerable<Employee> GetPreconfiguredGlossaryTerms()
        {
            return new List<Employee>()
             {
             new Employee() {Name="Tim",Description="CIO"},
             new Employee() {Name="Shyam", Description="Technical Go - to "}

             };
        }
    }
}
