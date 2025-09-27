using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Introduction.Controllers.Employees_2
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeV2Controller : ControllerBase
    {
        public EmployeeV2Controller() { }

        // Example 1: Route parameter
        // URL: https://localhost:7065/api/EmployeeV2/GetEmployeesList/1
        [HttpGet("GetEmployeesList/{id:int}")]
        public async Task<IActionResult> GetEmployeesList(int id)
        {
            var employeesList = await GetEmployees();
            var result = employeesList.Where(x => x.EmpId == id);

            if (!result.Any())
                return NotFound($"No employees found with the empid {id}");

            return Ok(result.First());
        }

        // Example 2: Route parameters (location + salary)
        // URL: https://localhost:7065/api/EmployeeV2/GetEmployeesListByLocationAndSalary/New%20York/28000
        [HttpGet("GetEmployeesListByLocationAndSalary/{location}/{salary:double}")]
        public async Task<IActionResult> GetEmployeesListByLocationAndSalary(string location, double salary)
        {
            var employeesList = await GetEmployees();
            var result = employeesList.Where(x => x.EmpLocation == location && x.EmpSalary > salary);

            if (!result.Any())
                return NotFound($"No employees found in {location} with salary > {salary}");

            return Ok(result);
        }

        // Example 3: Query parameter
        // URL: https://localhost:7065/api/EmployeeV2/GetEmployeesListByLocationWithQuery?location=New%20York
        [HttpGet("GetEmployeesListByLocationWithQuery")]
        public async Task<IActionResult> GetEmployeesListByLocationWithQuery([FromQuery] string location)
        {
            var employeesList = await GetEmployees();
            var result = employeesList.Where(x => x.EmpLocation == location);

            if (!result.Any())
                return NotFound($"No employees found in {location}");

            return Ok(result);
        }

        // Example 4: Multiple query parameters
        // URL: https://localhost:7065/api/EmployeeV2/GetEmployeesListByMultiQuery?empname=John&location=New%20York&salary=20000
        [HttpGet("GetEmployeesListByMultiQuery")]
        public async Task<IActionResult> GetEmployeesListByMultiQuery(
            [FromQuery] string empname,
            [FromQuery] string location,
            [FromQuery] double salary)
        {
            var employeesList = await GetEmployees();
            var result = employeesList.Where(x =>
                x.EmpLocation == location &&
                x.EmpSalary > salary &&
                x.EmpName == empname);

            if (!result.Any())
                return NotFound($"No employees found with name {empname}, location {location}, and salary > {salary}");

            return Ok(result);
        }

        // Fake DB
        private async Task<List<Employee>> GetEmployees()
        {
            await Task.Delay(500); // simulate async DB delay
            return new List<Employee>()
            {
                new Employee() { EmpId = 1, EmpName = "Michel", EmpLocation = "New York", EmpSalary = 20000.89 },
                new Employee() { EmpId = 2, EmpName = "Sarah",  EmpLocation = "London",   EmpSalary = 25000.50 },
                new Employee() { EmpId = 3, EmpName = "Ravi",   EmpLocation = "Bangalore",EmpSalary = 18000.00 },
                new Employee() { EmpId = 4, EmpName = "Emily",  EmpLocation = "New York", EmpSalary = 30000.75 },
                new Employee() { EmpId = 5, EmpName = "John",   EmpLocation = "New York", EmpSalary = 22000.40 }
            };
        }
    }

    // Employee model
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpLocation { get; set; }
        public double EmpSalary { get; set; }
    }
}
