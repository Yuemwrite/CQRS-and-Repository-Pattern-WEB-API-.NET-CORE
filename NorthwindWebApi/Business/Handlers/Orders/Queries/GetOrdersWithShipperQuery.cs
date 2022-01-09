using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Orders.Queries
{
    public class GetOrdersWithShipperQuery : IRequest<IResponse>
    {
        public class GetOrdersWithShipperQueryHandler : IRequestHandler<GetOrdersWithShipperQuery, IResponse>
        {
            private readonly IOrderRepository _orderRepository;

            public GetOrdersWithShipperQueryHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }
            public async Task<IResponse> Handle(GetOrdersWithShipperQuery request, CancellationToken cancellationToken)
            {
                var orders = await _orderRepository.GetOrdersWithShipperList();

                return new Response<IEnumerable<OrderWithShipperDto>>(orders);
            }
        }
    }
}
