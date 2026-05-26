using CoffeeShop.Data;
using CoffeeShop.Models.Domain;
using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Models.Services
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private CoffeeShopDbContext dbContext;
        public ShoppingCartRepository(CoffeeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }
        public string? ShoppingCartId { set; get; }

        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            CoffeeShopDbContext context = services.GetService<CoffeeShopDbContext>() ?? throw new Exception("Error initializing CoffeeShopDbContext");
            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);
            return new ShoppingCartRepository(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product)
        {
            var shoppingCartItem = dbContext.ShoppingCartItem.FirstOrDefault(s =>
           s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Qty = 1,
                };
                dbContext.ShoppingCartItem.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Qty++;
            }
            dbContext.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = dbContext.ShoppingCartItem.Where(s => s.ShoppingCartId ==
           ShoppingCartId);
            dbContext.ShoppingCartItem.RemoveRange(cartItems);
            dbContext.SaveChanges();
        }
        public List<ShoppingCartItem> GetAllShoppingCartItems()
        {
            return ShoppingCartItems ??= dbContext.ShoppingCartItem.Where(s => s.ShoppingCartId == ShoppingCartId).Include(p => p.Product).ToList();
        }
        public decimal GetShoppingCartTotal()
        {
            var totalCost = dbContext.ShoppingCartItem.Where(s => s.ShoppingCartId == ShoppingCartId)
            .Select(s => s.Product.Price * s.Qty).Sum();
            return totalCost;
        }
        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = dbContext.ShoppingCartItem.FirstOrDefault(s =>
           s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);
            var quantity = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Qty > 1)
                {
                    shoppingCartItem.Qty--;
                    quantity = shoppingCartItem.Qty;
                }
                else
                {
                    dbContext.ShoppingCartItem.Remove(shoppingCartItem);
                }
            }
            dbContext.SaveChanges();
            return quantity;
        }
    }
}
