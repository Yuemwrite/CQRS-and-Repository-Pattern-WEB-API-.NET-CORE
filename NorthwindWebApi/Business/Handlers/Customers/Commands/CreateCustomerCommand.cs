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
    public class CreateCustomerCommand : IRequest<IResponse>
    {
        public string CustomerId { get; set;}
        public string CompanyName { get; set; }

        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, IResponse>
        {
            private readonly ICustomerRepository _customerRepository;

            public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }
            public async Task<IResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer addedCustomer = new Customer();
                addedCustomer.CustomerId = request.CustomerId;
                addedCustomer.CompanyName = request.CompanyName;
                addedCustomer.ContactName = request.ContactName;
                addedCustomer.ContactTitle = request.ContactTitle;
                addedCustomer.Address = request.Address;
                addedCustomer.City = request.City;
                addedCustomer.Region = request.Region;
                addedCustomer.PostalCode = request.PostalCode;
                addedCustomer.Country = request.Country;
                addedCustomer.Phone = request.Phone;    
                addedCustomer.Fax = request.Fax;

                _customerRepository.Add(addedCustomer);
                await _customerRepository.SaveChangesAsync();

                return new Response<Customer>(addedCustomer);
            }
        }

    }
}
