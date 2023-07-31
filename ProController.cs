using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Mo
{
    public class ProController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Products/dfj")]
        public JsonResult Som()
        {
            List<Products> Paw = new List<Products>();


            Paw.Add(new Products
            {
                Id = 1,
                Title = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
                Price = "109.95",
                Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
                Category = "men's clothing",
                Image = "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg"
            });
            
            
            Paw.Add(new Products {Id= 1,
        Title= "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
        Price= "109.95",
        Description= "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
        Category= "men's clothing",
        Image= "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg" });
            return Json(new { i = Paw });
        }

    }
}
