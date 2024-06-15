using unit_testing_dotnetcore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace unit_testing_dotnetcore.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Add(Product product);
        List<Product> GetAll();
    }
}
