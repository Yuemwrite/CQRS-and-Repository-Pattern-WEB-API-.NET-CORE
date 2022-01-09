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
    public class UpdateSupplierCommand : IRequest<IResponse>
    {
        public int SupplierId { get; set; }
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

        public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, IResponse>
        {
            private readonly ISupplierRepository _supplierRepository;

            public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository)
            {
                _supplierRepository = supplierRepository;
            }
            public async Task<IResponse> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
            {
                Supplier updateSupplier = _supplierRepository.Get(_=>_.SupplierId == request.SupplierId);

                updateSupplier.CompanyName = request.CompanyName;
                updateSupplier.ContactName = request.ContactName;
                updateSupplier.ContactTitle = request.ContactTitle;
                updateSupplier.Address = request.Address;
                updateSupplier.City = request.City;
                updateSupplier.Region = request.Region;
                updateSupplier.Country = request.Country;
                updateSupplier.PostalCode = request.PostalCode;
                updateSupplier.Phone = request.Phone;
                updateSupplier.Fax = request.Fax;

                _supplierRepository.Update(updateSupplier);
                await _supplierRepository.SaveChangesAsync();

                return new Response<Supplier>(updateSupplier);
            }
        }
    }
}
