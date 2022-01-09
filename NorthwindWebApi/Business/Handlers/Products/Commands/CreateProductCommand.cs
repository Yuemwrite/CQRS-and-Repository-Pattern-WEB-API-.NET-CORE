using Core.Wrappers;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Products.Commands
{
    public class CreateProductCommand : IRequest<IResponse>
    {
        public string ProductName { get; set; }

        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }

        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryId { get; set; } 

        public int SupplierId { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, IResponse>
        {
            private readonly IProductRepository _productRepository;

            public CreateProductCommandHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<IResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                Product addedProduct = new Product();
                addedProduct.ProductName = request.ProductName;
                addedProduct.CategoryId = request.CategoryId;
                addedProduct.SupplierId = request.SupplierId;
                addedProduct.UnitPrice = request.UnitPrice;
                addedProduct.UnitsInStock = request.UnitsInStock;
                addedProduct.UnitsOnOrder = request.UnitsOnOrder;
                addedProduct.ReorderLevel = request.ReorderLevel;
                addedProduct.Discontinued = request.Discontinued;

                _productRepository.Add(addedProduct);
                await _productRepository.SaveChangesAsync();

                return new Response<Product>(addedProduct); 

            }
        }
    }
}
