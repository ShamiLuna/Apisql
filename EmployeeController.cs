using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Employee/GetDetails")]
        public JsonResult GetDetails()
        {
            return Json(new {name = "test", age = 20, gender = "Female"  });
        }

        [HttpGet("Employee/GetEmpList")]
        public JsonResult GetEmpDetails()
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee { Id = 1, Name = "test", Description = "jsdxnsanx" });
            list.Add(new Employee { Id = 1, Name = "test", Description = "jsdxnsanx" });
            list.Add(new Employee { Id = 1, Name = "test", Description = "jsdxnsanx" });
            return Json(new {x = list});
        }
    }
}
