
using Microsoft.AspNetCore.Mvc;

namespace Introduction
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeV2WithDI : ControllerBase
    {
        private readonly IEmployeeV2Repository _repo;

        public EmployeeV2WithDI(IEmployeeV2Repository repo)
        {
            _repo = repo;  // injected via DI
        }

        // GET: https://localhost:7065/api/EmployeeV2WithDI/GetAllEmployees
        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmp()
        {
            await Task.Delay(1000); // simulate async
            var result = _repo.Employees();
            return Ok(result);
        }
    }

    public interface IEmployeeV2Repository
    {
        List<EmployeeV2> Employees();
    }

    // Repository Implementation
    public class InMemoryEmployeeRepository : IEmployeeV2Repository
    {
        public List<EmployeeV2> Employees()
        {
            return new List<EmployeeV2>
            {
                new EmployeeV2 { Id = 1, Name = "John", Department = "IT" },
                new EmployeeV2 { Id = 2, Name = "Sara", Department = "HR" },
                new EmployeeV2 { Id = 3, Name = "Ravi", Department = "Finance" }
            };
        }
    }

    public class EmployeeV2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
}

