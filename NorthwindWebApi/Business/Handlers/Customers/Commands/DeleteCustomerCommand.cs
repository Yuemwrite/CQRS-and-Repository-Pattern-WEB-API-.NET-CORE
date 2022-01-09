using Core.Constants;
using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<IResponse>
    {
        public string CustomerId { get; set; }

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, IResponse>
        {
            private readonly ICustomerRepository _customerRepository;

            public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }
            public async Task<IResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer deletedCustomer = await _customerRepository.GetAsync(_=>_.CustomerId == request.CustomerId);

                _customerRepository.Delete(deletedCustomer);
                await _customerRepository.SaveChangesAsync();

                return new Response<Customer>(deletedCustomer, "Customer successfuly deleted");
            }
        }
    }
}
