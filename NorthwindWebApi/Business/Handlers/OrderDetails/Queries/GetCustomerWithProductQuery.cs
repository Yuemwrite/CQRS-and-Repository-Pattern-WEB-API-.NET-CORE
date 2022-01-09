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
    public class GetCustomerWithProductQuery : IRequest<IResponse>
    {
        public class GetCustomerWithProductQueryHandler : IRequestHandler<GetCustomerWithProductQuery, IResponse>
        {
            private IOrderDetailsRepository _orderDetailsRepository;

            public GetCustomerWithProductQueryHandler(IOrderDetailsRepository orderDetailsRepository)
            {
                _orderDetailsRepository = orderDetailsRepository;
            }
            public async Task<IResponse> Handle(GetCustomerWithProductQuery request, CancellationToken cancellationToken)
            {
                var customerProducts = await _orderDetailsRepository.GetCustomerWithProductList();

                return new Response<IEnumerable<CustomerWithProductDto>>(customerProducts);
            }
        }
    }
}
