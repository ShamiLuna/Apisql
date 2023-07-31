using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class sqlcoController : Controller
    {

        private readonly IConfiguration _configuration;
        public sqlcoController(IConfiguration Configuration)
        {

            _configuration = Configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Teacher/info")]
        public JsonResult InsertStudent([FromBody] Teachers stude)
        {
            bool res = false;
            string constr = _configuration.GetConnectionString("con");

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "INSERT INTO Teachers values (" + stude.Id + "," + stude.Name + "," + stude.City + "," + stude.Father + "," + stude.Degree+")";
                SqlCommand cmd = new SqlCommand("TEACHERSP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", stude.Id);
                cmd.Parameters.AddWithValue("@Name", stude.Name);
                cmd.Parameters.AddWithValue("@City", stude.City);
                cmd.Parameters.AddWithValue("@Father", stude.Father);
                cmd.Parameters.AddWithValue("@Degree", stude.Degree);

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                res = true;
                con.Close();

                return Json(new { success = res });
            }

            return Json(new { });
        }


    }
}

    