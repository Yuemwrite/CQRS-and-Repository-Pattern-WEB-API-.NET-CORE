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
    public class GetOrdersWithEmployeeQuery : IRequest<IResponse>
    {
        public class GetOrdersWithEmployeeQueryHandler : IRequestHandler<GetOrdersWithEmployeeQuery, IResponse>
        {
            private readonly IOrderRepository _orderRepository;

            public GetOrdersWithEmployeeQueryHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }
            public async Task<IResponse> Handle(GetOrdersWithEmployeeQuery request, CancellationToken cancellationToken)
            {
                var orderEmployees = await _orderRepository.GetOrdersWithEmployeeList();

                return new Response<IEnumerable<OrderWithEmployeeDto>>(orderEmployees);
            }
        }
    }
}
