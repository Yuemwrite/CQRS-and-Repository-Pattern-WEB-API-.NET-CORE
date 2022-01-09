using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Orders.Queries
{
    public class GetOrdersQuery : IRequest<IResponse>
    {
        public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IResponse>
        {
            private readonly IOrderRepository _orderRepository;

            public GetOrdersQueryHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }
            public async Task<IResponse> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
            {
                var orders = await _orderRepository.GetListAsync();
                return new Response<IEnumerable<Order>>(orders);
            }
        }
    }
}
