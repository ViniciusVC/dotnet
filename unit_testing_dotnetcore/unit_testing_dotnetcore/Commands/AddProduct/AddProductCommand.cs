using unit_testing_dotnetcore.Entities;
using MediatR;

namespace unit_testing_dotnetcore.Commands.AddProduct
{
    public class AddProductCommand : IRequest<Product>
    {
        public AddProductCommand(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
    }
}
