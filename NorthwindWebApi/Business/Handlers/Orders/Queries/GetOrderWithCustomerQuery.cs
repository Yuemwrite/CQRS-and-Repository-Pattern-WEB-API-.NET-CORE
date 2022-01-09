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
    public class GetOrderWithCustomerQuery : IRequest<IResponse>
    {
        public class GetOrderWithCustomerQueryHandler : IRequestHandler<GetOrderWithCustomerQuery, IResponse>
        {
            private readonly IOrderRepository _orderRepository;

            public GetOrderWithCustomerQueryHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<IResponse> Handle(GetOrderWithCustomerQuery request, CancellationToken cancellationToken)
            {
                var orders = await _orderRepository.GetOrdersWithCustomerList();

                return new Response<IEnumerable<OrderWithCustomerDto>>(orders);
            }
        }
    }
}
