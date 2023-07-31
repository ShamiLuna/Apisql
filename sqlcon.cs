using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class sqlcon : Controller
    {
        private readonly IConfiguration _configuration;
        public sqlcon(IConfiguration Configuration)
        {

            _configuration = Configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("stuid/Somth")]
        public JsonResult tos()
        {
            string constr = _configuration.GetConnectionString("con");
            List<student> list = new List<student>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "select distinct NAME from STUD";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sd = cmd.ExecuteReader())
                    {
                        while (sd.Read())

                        {
                            list.Add(new student
                            {
                                NAME = sd["NAME"].ToString(),
                                ROLLNO = sd["ROLLNO"].ToString(),
                               MOBILENO = sd["MOBILENO"].ToString(),
                                CITY= sd["CITY"].ToString(),
                                email = sd["email"].ToString(),
                            });
                        }
                    }
                    con.Close();
                }
                return Json(new { sto = list });
            }

        }

        [HttpPost("Student/AddStudent")]
        public JsonResult InsertStudent([FromBody] student stu)
        {
            bool res = false;
            string constr = _configuration.GetConnectionString("con");
           // List<student> list = new List<student>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                //string query = "INSERT INTO Stud values (" + stu.NAME + "," + stu.ROLLNO + "," + stu.MOBILENO + "," + stu.CITY + "," + stu.email+")";
                SqlCommand cmd = new SqlCommand("StudentSP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", stu.NAME);
                cmd.Parameters.AddWithValue("@rollno", stu.ROLLNO);
                cmd.Parameters.AddWithValue("@mobile", stu.MOBILENO);
                cmd.Parameters.AddWithValue("@city", stu.CITY);
                cmd.Parameters.AddWithValue("@email", stu.email);
              
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
