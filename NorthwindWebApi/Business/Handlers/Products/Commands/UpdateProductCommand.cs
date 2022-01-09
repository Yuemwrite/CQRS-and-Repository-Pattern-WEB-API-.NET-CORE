using Core.Wrappers;
using DataAccess.Concrete;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Products.Commands
{
    public class UpdateProductCommand : IRequest<IResponse>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }

        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, IResponse>
        {
            private readonly IProductRepository _productRepository;

            public UpdateProductCommandHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<IResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Product updatedProduct = _productRepository.Get(_=>_.ProductId == request.ProductId);

                updatedProduct.ProductName = request.ProductName;
                updatedProduct.CategoryId = request.CategoryId;
                updatedProduct.SupplierId = request.SupplierId;
                updatedProduct.UnitPrice = request.UnitPrice;
                updatedProduct.UnitsOnOrder = request.UnitsOnOrder;
                updatedProduct.QuantityPerUnit = request.QuantityPerUnit;
                updatedProduct.UnitsInStock = request.UnitsInStock;
                updatedProduct.Discontinued= request.Discontinued;

                _productRepository.Update(updatedProduct);
                await _productRepository.SaveChangesAsync();

                return new Response<Product>(updatedProduct);

            }
        }
    }
}
