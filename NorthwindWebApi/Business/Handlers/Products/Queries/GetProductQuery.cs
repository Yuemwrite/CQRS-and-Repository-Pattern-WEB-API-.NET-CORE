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
    public class GetProductQuery : IRequest<IResponse>
    {
        public int ProductId { get; set; }
        public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IResponse>
        {
            private readonly IProductRepository _productRepository;

            public GetProductQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<IResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var currentProduct = await _productRepository.GetAsync(_=>_.ProductId == request.ProductId);

                return new Response<Product>(currentProduct);
            }
        }
    }
}
