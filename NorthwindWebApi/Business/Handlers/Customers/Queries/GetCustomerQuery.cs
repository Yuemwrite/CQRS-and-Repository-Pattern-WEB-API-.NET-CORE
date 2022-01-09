using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Products.Queries
{
    public class GetCustomerQuery : IRequest<IResponse>
    {
        public string CustomerId { get; set; }

        public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, IResponse>
        {
            private readonly ICustomerRepository _customerRepository;

            public GetCustomerQueryHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<IResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
            {
                var currentCustomer = await _customerRepository.GetAsync(_=>_.CustomerId == request.CustomerId);

                return new Response<Customer>(currentCustomer);
            }
        }
    }
}
