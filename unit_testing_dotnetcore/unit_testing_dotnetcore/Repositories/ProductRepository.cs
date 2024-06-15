using unit_testing_dotnetcore.Context;
using unit_testing_dotnetcore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace unit_testing_dotnetcore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _storeDbContext;
        public ProductRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public async Task<Product> Add(Product product)
        {
            await _storeDbContext.Products.AddAsync(product);

            return product;
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
