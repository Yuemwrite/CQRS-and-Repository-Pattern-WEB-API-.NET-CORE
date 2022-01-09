using Core.Wrappers;
using DataAccess.Concrete;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Products.Queries
{
    public class GetProductsQuery : IRequest<IResponse> 
    {
        public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IResponse>
        {
            private readonly IProductRepository _productRepository;

            public GetProductsQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<IResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetListAsync();
                return new Response<IEnumerable<Product>>(products);
            }
        }
    }
}
