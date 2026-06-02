using CoffeeShop.Models;
using CoffeeShop.Models.Services;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models.Interfaces;

namespace CoffeeShop.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contactRepository.SendContact(contact);
            return RedirectToAction("ContactSuccess");
        }
        public IActionResult ContactSuccess()
        {
            return View();
        }
    }
}
