using unit_testing_dotnetcore.Context;
using unit_testing_dotnetcore.Entities;
using unit_testing_dotnetcore.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace unit_testing_dotnetcore.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Title, request.Description, request.Price);

            var productDb = await _productRepository.Add(product);

            return productDb;
        }
    }
}
