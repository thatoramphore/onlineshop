using Microsoft.EntityFrameworkCore;
using OnlineShop.Api.Data;
using OnlineShop.Api.Entities;
using OnlineShop.Api.Repositories.Contracts;

namespace OnlineShop.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopDbContext onlineShopDbContext;

        public ProductRepository(OnlineShopDbContext onlineShopDbContext)
        {
            this.onlineShopDbContext = onlineShopDbContext;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            //return a collection of product categories from DB
            var categories = await this.onlineShopDbContext.ProductCategories.ToListAsync();

            return categories;
        }

        public Task<ProductCategory> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetItems(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            //return a collection of Products from DB
            var products = await this.onlineShopDbContext.Products.ToListAsync();

            return products;
        }
    }
}
