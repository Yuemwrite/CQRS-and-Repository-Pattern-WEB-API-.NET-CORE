using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Queries
{
    public class GetCustomersQuery : IRequest<IResponse>
    {
        public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IResponse>
        {
            private readonly ICustomerRepository _customerRepository;

            public GetCustomersQueryHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }
            public async Task<IResponse> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
            {
                var customers = await _customerRepository.GetListAsync();
                return new Response<IEnumerable<Customer>>(customers);
            }
        }
    }
}
