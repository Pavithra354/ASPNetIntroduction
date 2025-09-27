using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers.Employees_3
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeV3Controller : ControllerBase
    {
        public EmployeeV3Controller() { }

        // GET: api/EmployeeV3/GetEmployeesListByLocatinAndSalaryWithMultiQueryParamsWithDTO
        [HttpGet]
        [Route("GetEmployeesListByLocatinAndSalaryWithMultiQueryParamsWithDTO")]
        public async Task<IActionResult> GetEmployeesListByLocatinAndSalaryWithQueryWithDTO(
           [FromQuery] EmployeeDTO employee)
        {
            var employeesList = await GetEmployees();

            var result = employeesList
                .Where(x => x.EmpLocation == employee.Location &&
                            x.EmpSalary > employee.Salary &&
                            x.EmpName == employee.EmpName);

            if (!result.Any())
            {
                return NotFound($"No employees found with salary > {employee.Salary} and location {employee.Location}");
            }

            return Ok(result);
        }

        // POST: api/EmployeeV3/GetEmployeesList_filter
        [HttpPost]
        [Route("GetEmployeesList_filter")]
        public async Task<IActionResult> GetEmployeesList_filter([FromBody] EmployeeDTO employee)
        {
            var employeesList = await GetEmployees();

            var result = employeesList
                .Where(x => x.EmpLocation == employee.Location &&
                            x.EmpSalary > employee.Salary &&
                            x.EmpName == employee.EmpName);

            if (!result.Any())
            {
                return NotFound($"No employees found with salary > {employee.Salary} and location {employee.Location}");
            }

            return Ok(result);
        }

        // POST: api/EmployeeV3/CreateEmployee
        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] NewEmployeeDTO newEmployee)
        {
            var result = await NewEmployee(newEmployee);

            if (result == "Failed")
            {
                return BadRequest("Employee details are invalid. Please provide proper details.");
            }

            return Created("api/EmployeeV3/CreateEmployee", newEmployee);
        }

        // POST: api/EmployeeV3/CreateEmployee1
        [HttpPost]
        [Route("CreateEmployee1")]
        public async Task<IActionResult> CreateEmployee1()
        {
            await Task.Delay(1000);
            return Ok("Success");
        }

        private async Task<string> NewEmployee(NewEmployeeDTO newEmployee)
        {
            await Task.Delay(2000);

            if (string.IsNullOrWhiteSpace(newEmployee.Name))
            {
                return "Failed";
            }

            return "Success";
        }

        private async Task<List<Employee>> GetEmployees()
        {
            await Task.Delay(2000);
            return _store();
        }

        private List<Employee> _store()
        {
            return new List<Employee>
            {
                new Employee { EmpId = 1, EmpName = "Michel", EmpLocation = "New York", EmpSalary = 20000.89 },
                new Employee { EmpId = 2, EmpName = "Sarah",  EmpLocation = "London",   EmpSalary = 25000.50 },
                new Employee { EmpId = 3, EmpName = "Ravi",   EmpLocation = "Bangalore",EmpSalary = 18000.00 },
                new Employee { EmpId = 4, EmpName = "Emily",  EmpLocation = "New York", EmpSalary = 30000.75 },
                new Employee { EmpId = 5, EmpName = "John",   EmpLocation = "New York", EmpSalary = 22000.40 }
            };
        }
    }

    // DTOs and Models

    public class EmployeeDTO
    {
        public string EmpName { get; set; }
        public string Location { get; set; }
        public double Salary { get; set; }
    }


    //https://localhost:7051/api/EmployeeV3/CreateEmployee

    public class NewEmployeeDTO
    {
        public string? Name { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime? DOB { get; set; }
        public string? StreetAdress { get; set; }
    }

    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpLocation { get; set; }
        public double EmpSalary { get; set; }
    }
}
