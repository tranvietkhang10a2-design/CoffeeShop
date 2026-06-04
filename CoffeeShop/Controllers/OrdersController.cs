using CoffeeShop.Models;
using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private IOrderRepository orderRepository;
        private IShoppingCartRepository shoppingCartRepository;
        private readonly UserManager<IdentityUser> userManager;
        public OrdersController(IOrderRepository oderRepository, IShoppingCartRepository shoppingCartRepossitory, UserManager<IdentityUser> userManager)
        {
            this.orderRepository = oderRepository;
            this.shoppingCartRepository = shoppingCartRepossitory;
            this.userManager = userManager;
        }
        public IActionResult CheckOut()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            order.UserId = userManager.GetUserId(User);
            orderRepository.PlaceOrder(order);
            shoppingCartRepository.ClearCart();
            HttpContext.Session.SetInt32("CartCount", 0);
            return RedirectToAction("CheckoutComplete");
        }
        public IActionResult CheckOutComplete()
        {
            return View();
        }
        public IActionResult UserOrderList()
        {
            var userId = userManager.GetUserId(User);
            var orders = orderRepository.GetOrdersByUser(userId);
            return View(orders);
        }

    }
}
