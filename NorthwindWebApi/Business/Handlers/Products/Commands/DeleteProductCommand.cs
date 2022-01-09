using Core.Wrappers;
using DataAccess.Concrete;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Products.Commands;

public class DeleteProductCommand : IRequest<IResponse>
{
    public int ProductId { get; set; }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, IResponse>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product deletedProduct = await _productRepository.GetAsync(_ => _.ProductId == request.ProductId);

            _productRepository.Delete(deletedProduct);
            await _productRepository.SaveChangesAsync();

            return new Response<Product>(deletedProduct);
        }
    }
}
