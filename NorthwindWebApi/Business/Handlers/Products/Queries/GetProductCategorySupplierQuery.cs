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
    public class GetProductCategorySupplierQuery : IRequest<IResponse>
    {
        public class ProductCategorySupplierQueryHandler : IRequestHandler<GetProductCategorySupplierQuery, IResponse>
        {
            public IProductRepository _productRepository;

            public ProductCategorySupplierQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<IResponse> Handle(GetProductCategorySupplierQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetProductSupplierCategoryList();
                return new Response<IEnumerable<ProductSupplierCategoryDto>>(products);
            }
        }
    }
}
