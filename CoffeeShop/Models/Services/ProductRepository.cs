using CoffeeShop.Data;
using CoffeeShop.Models.Domain;
using CoffeeShop.Models.Interfaces;
namespace CoffeeShop.Models.Services
{
    public class ProductRepository : IProductRepository
    {
        //private List<Product> ProductList = new List<Product>()
        //{
        //    new Product { Id = 1, Name = "America", Price = 25, Detail = "Name Product", ImgUrl = "https://index.com" },
        //    new Product { Id = 2, Name = "VietNam", Price = 20, Detail = "Vietnamese Product", ImgUrl = "https://index.com" },
        //    new Product { Id = 3, Name = "United Kingdom", Price = 15, Detail = "Name Product", ImgUrl = "https://index.com" }
        //};
        //public IEnumerable<Product> GetAllProducts()
        //{
        //    return ProductList;
        //}
        //public Product GetProductDetail(int id)
        //{
        //    return ProductList.FirstOrDefault(p => p.Id == id);
        //}
        //public IEnumerable<Product> GetTrendingProducts()
        //{
        //    return ProductList.Where(p => p.IsTrendingProduct);
        //}
        private CoffeeShopDbContext dbContext;
        public ProductRepository(CoffeeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return dbContext.Products;
        }
        public Product? GetProductDetail(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Product> GetTrendingProducts()
        {
            return dbContext.Products.Where(p => p.IsTrendingProduct);

        }
    }
}
