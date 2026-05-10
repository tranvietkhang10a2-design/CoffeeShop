using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository ProductRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.ProductRepository = productRepository;
        }
        public IActionResult Shop()
        {
            return View(ProductRepository.GetAllProducts());
        }
    }
}
