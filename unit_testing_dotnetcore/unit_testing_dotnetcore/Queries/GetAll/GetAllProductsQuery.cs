using MediatR;
using System.Collections.Generic;

namespace unit_testing_dotnetcore.Queries.GetAll
{
    public class GetAllProductsQuery : IRequest<List<GetAllProductsViewModel>>
    {
    }
}
