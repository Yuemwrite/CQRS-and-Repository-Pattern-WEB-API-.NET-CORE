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

    public class GetrOrderShipperEmployeeQuery : IRequest<IResponse>
    {
        public class GetOrderShipperEmployeeQueryHandler : IRequestHandler<GetrOrderShipperEmployeeQuery, IResponse>
        {
            private readonly IOrderRepository _orderRepository;

            public GetOrderShipperEmployeeQueryHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }
            public async Task<IResponse> Handle(GetrOrderShipperEmployeeQuery request, CancellationToken cancellationToken)
            {
                var orders = await _orderRepository.GetOrderShipperEmployeeList();
                return new Response<IEnumerable<OrderShipperEmployeeDto>>(orders);
            }
        }
    }
}
