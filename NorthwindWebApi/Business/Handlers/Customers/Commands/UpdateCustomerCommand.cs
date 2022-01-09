using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Products.Commands
{
    public class UpdateCustomerCommand : IRequest<IResponse>
    {
        public string CustomerId { get; set; }
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

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, IResponse>
        {
            private readonly ICustomerRepository _customerRepository;

            public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<IResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer updateCustomer = _customerRepository.Get(_=>_.CustomerId == request.CustomerId);

                updateCustomer.CompanyName = request.CompanyName;
                updateCustomer.ContactName = request.ContactName;
                updateCustomer.ContactTitle = request.ContactTitle;
                updateCustomer.Address = request.Address;
                updateCustomer.City = request.City;
                updateCustomer.Region = request.Region;
                updateCustomer.PostalCode = request.PostalCode;
                updateCustomer.Country = request.Country;
                updateCustomer.Phone = request.Phone;
                updateCustomer.Fax = request.Fax;

                _customerRepository.Update(updateCustomer);
                await _customerRepository.SaveChangesAsync();

                return new Response<Customer>(updateCustomer);
            }
        }
    }
}
