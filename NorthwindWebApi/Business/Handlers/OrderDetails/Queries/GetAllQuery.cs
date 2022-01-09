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
    public class GetAllQuery : IRequest<IResponse>
    {
        public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IResponse>
        {
            private readonly IOrderDetailsRepository _orderDetailsRepository;

            public GetAllQueryHandler(IOrderDetailsRepository orderDetailsRepository)
            {
                _orderDetailsRepository = orderDetailsRepository;
            }
            public async Task<IResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
            {
                var getAlls = await _orderDetailsRepository.GetCustomerOrderEmployeeProductCategorySupplierList();

                return new Response<IEnumerable<CustomerOrderEmployeeProductCategorySupplierDto>>(getAlls);
            }
        }
    }
}
