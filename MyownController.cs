using Microsoft.AspNetCore.Mvc;
using WebApplication1.Mo;

namespace WebApplication1.Controllers
{
    public class MyownController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Myown/getmyd")]
        public JsonResult getmyd()
        {
            return Json(new { name = "Shamina", Pincode = 643001, Father = "Sirajdeen" });
        }

        [HttpGet("BankDetails/a")]
        public JsonResult Yedho() { 
            List<BankDetails> Sha = new List<BankDetails>();
            Sha.Add(new BankDetails { Id = 1, Name = "Shamina", AccountNumber = 454857287 });
            Sha.Add(new BankDetails { Id = 2, Name = "Rabiya", AccountNumber = 454857287 });
            Sha.Add(new BankDetails { Id = 3, Name = "mina", AccountNumber = 67676675747857 });
            return Json(new {b = Sha ,Count = Sha.Count});

        }
    }
}
