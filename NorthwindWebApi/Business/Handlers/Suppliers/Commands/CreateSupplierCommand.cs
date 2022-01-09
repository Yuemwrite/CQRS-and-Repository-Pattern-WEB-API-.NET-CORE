using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Suppliers.Commands
{
    public class CreateSupplierCommand : IRequest<IResponse>
    {
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

        public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, IResponse>
        {
            private readonly ISupplierRepository _supplierRepository;

            public CreateSupplierCommandHandler(ISupplierRepository supplierRepository)
            {
                _supplierRepository = supplierRepository;
            }
            public async Task<IResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
            {
                Supplier addedSuplier = new Supplier();
                addedSuplier.CompanyName = request.CompanyName;
                addedSuplier.ContactName = request.ContactName;
                addedSuplier.ContactTitle = request.ContactTitle;
                addedSuplier.Address = request.Address;
                addedSuplier.City = request.City;
                addedSuplier.Region = request.Region;
                addedSuplier.PostalCode = request.PostalCode;
                addedSuplier.Country = request.Country;
                addedSuplier.Phone = request.Phone;
                addedSuplier.Fax = request.Fax;

                _supplierRepository.Add(addedSuplier);
                await _supplierRepository.SaveChangesAsync();

                return new Response<Supplier>(addedSuplier);
            }
        }
    }
}
