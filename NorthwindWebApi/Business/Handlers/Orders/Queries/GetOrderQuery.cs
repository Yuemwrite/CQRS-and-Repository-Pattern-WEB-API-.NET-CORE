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
    public class GetOrderQuery : IRequest<IResponse>
    {
        public int OrderId { get; set; }

        public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, IResponse>
        {
            private readonly IOrderRepository _orderRepository;

            public GetOrderQueryHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }
            public async Task<IResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
            {
                var currentOrder = await _orderRepository.GetAsync(_=>_.OrderId == request.OrderId);

                return new Response<Order>(currentOrder);
            }
        }
    }
}
