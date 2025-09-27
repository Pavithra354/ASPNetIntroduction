using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Introduction.Controllers
{
    //https://localhost:7051/api/EmployeeV1/GetEmployeesList

    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeV1Controller : ControllerBase
    {
        public EmployeeV1Controller() { }

       

        [HttpGet]  
        [Route("GetEmployeesList")]
        public async Task<IActionResult> GetEmployeesList()
        {
            string EmpName = "Madan";


            var employeesList = await GetEmployees();  


            var count = employeesList.Where(x => x == EmpName).Count();

            if (count == 0)
            {
                return NotFound($"No employees found with the name of {EmpName} ");   // 404 Not found
            }
            return Ok(new List<string> { "JOHN", "PEter" });  // 200 success code . json
        }

        private async Task<List<string>> GetEmployees()
        {
            await Task.Delay(2000);
            return _store();
        }


        private List<string> _store()
        {

            return new List<string> { "JOHN", "PEter", "PEter" };
        }





    }
}






