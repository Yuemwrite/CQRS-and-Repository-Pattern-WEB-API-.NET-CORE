using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.OrderDetails.Queries
{
    public class GetOrderWithProductQuery : IRequest<IResponse>
    {
        public class GetOrderWithProductQueryHandler : IRequestHandler<GetOrderWithProductQuery, IResponse>
        {
            private readonly IOrderDetailsRepository _orderDetailsRepository;

            public GetOrderWithProductQueryHandler(IOrderDetailsRepository orderDetailsRepository)
            {
                _orderDetailsRepository = orderDetailsRepository;
            }
            public async Task<IResponse> Handle(GetOrderWithProductQuery request, CancellationToken cancellationToken)
            {
                var orderWithProducts = await _orderDetailsRepository.GetOrderWithProductList();
                return new Response<IEnumerable<OrderWithProductDto>>(orderWithProducts);
            }
        }
    }
}
