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
    public class DeleteSupplierCommand : IRequest<IResponse>
    {
        public int SupplierId { get; set; }

        public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, IResponse>
        {
            private readonly ISupplierRepository _supplierRepository;

            public DeleteSupplierCommandHandler(ISupplierRepository supplierRepository)
            {
                _supplierRepository = supplierRepository;
            }
            public async Task<IResponse> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
            {
                Supplier deletedSupplier = await  _supplierRepository.GetAsync(_=>_.SupplierId == request.SupplierId);

                _supplierRepository.Delete(deletedSupplier);
                await _supplierRepository.SaveChangesAsync();

                return new Response<Supplier>(deletedSupplier);
            }
        }
    }
}
