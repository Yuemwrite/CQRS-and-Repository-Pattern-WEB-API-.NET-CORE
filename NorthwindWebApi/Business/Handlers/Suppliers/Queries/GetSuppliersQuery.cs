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
    public class GetSuppliersQuery : IRequest<IResponse>
    {
        public class GetSuppliersQueryHandler : IRequestHandler<GetSuppliersQuery, IResponse>
        {
            private readonly ISupplierRepository _supplierRepository;

            public GetSuppliersQueryHandler(ISupplierRepository supplierRepository)
            {
                _supplierRepository = supplierRepository;
            }
            public async Task<IResponse> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
            {
                var suppliers = await _supplierRepository.GetListAsync();
                return new Response<IEnumerable<Supplier>>(suppliers);
            }
        }
    }
}
