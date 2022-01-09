using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Suppliers.Queries
{
    public class GetSupplierQuery : IRequest<IResponse>
    {
        public int SupplierId { get; set; }

        public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQuery, IResponse>
        {
            public ISupplierRepository _supplierRepository;

            public GetSupplierQueryHandler(ISupplierRepository supplierRepository)
            {
                _supplierRepository = supplierRepository;
            }
            public async Task<IResponse> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
            {
                var currentSupplier = await _supplierRepository.GetAsync(_=>_.SupplierId == request.SupplierId);
                return new Response<Supplier>(currentSupplier);
            }
        }
    }
}
