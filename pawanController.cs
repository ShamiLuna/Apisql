using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Student.Controllers.Model;

namespace Student.Controllers
{
    public class pawanController : Controller
    {
        private readonly IConfiguration _configuration;
        public pawanController(IConfiguration Configuration)
        {

            _configuration = Configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Student/GetDetails")]
        public JsonResult GetDetails()
        {
            return Json(new { name = "hi", age = 20 });
        }
        [HttpGet("Student/GetpawanDetails")]
        public JsonResult GetpawanDetails()
        {
            List<pawan> list = new List<pawan>();
            list.Add(new pawan { Id = 1, Name = "Pawan", Age = 20 });
            list.Add(new pawan { Id = 2, Name = "Rukshana", Age = 20 });
            list.Add(new pawan { Id = 3, Name = "Shamina", Age = 20 });

            return Json(new { pawList = list, count = list.Count });
        }
        [HttpGet("Student/GetDetails1")]
        public JsonResult GetStudentDetails()
        {
            string constr = _configuration.GetConnectionString("con");
            List<stud> stdList = new List<stud>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * from Student where age > 10";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            stdList.Add(new stud
                            {
                                RollNo = sdr["ROLL NO"].ToString(),
                                name = sdr["NAME"].ToString(),
                                studClass = sdr["CLASS"].ToString(),
                                age = int.Parse(sdr["AGE"].ToString())
                            });
                        }
                    }
                    con.Close();
                }
                return Json(new { stdL = stdList });

            }



        }
    }
}
