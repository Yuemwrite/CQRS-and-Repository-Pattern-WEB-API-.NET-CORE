using Core.Wrappers;
using DataAccess.Concrete;
using Entities.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Products.Queries
{
    public class GetProductsWithSupplierQuery : IRequest<IResponse>
    {
        public class GetProductsWithSupplierQueryHandler : IRequestHandler<GetProductsWithSupplierQuery, IResponse>
        {
            public IProductRepository _productRepository;

            public GetProductsWithSupplierQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<IResponse> Handle(GetProductsWithSupplierQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetProductWithSupplierList();
                return new Response<IEnumerable<ProductWithSupplierDto>>(products);
            }
        }
    }
}
