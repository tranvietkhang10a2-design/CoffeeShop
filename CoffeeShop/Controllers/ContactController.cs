using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Index(string name, string email, string message)
        //{
        //    ViewBag.Success = "Gửi thành công!";
        //    return View();
        //}
    }
}
