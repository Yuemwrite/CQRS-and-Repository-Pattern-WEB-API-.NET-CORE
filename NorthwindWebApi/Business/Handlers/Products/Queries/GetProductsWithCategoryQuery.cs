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
    public class GetProductsWithCategoryQuery : IRequest<IResponse>
    {
        public class GetProductsWithCategoryQueryHandler : IRequestHandler<GetProductsWithCategoryQuery, IResponse>
        {
            private readonly IProductRepository _productRepository;

            public GetProductsWithCategoryQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<IResponse> Handle(GetProductsWithCategoryQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetProductsWithCategoryList();

                return new Response<IEnumerable<ProductWithCategoryDto>>(
                    products);
            }

           
        }
    }
}
