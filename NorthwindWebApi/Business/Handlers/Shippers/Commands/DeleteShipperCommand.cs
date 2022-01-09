using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Shippers.Commands
{
    public class DeleteShipperCommand : IRequest<IResponse>
    {
        public int ShipperId { get; set; }

        public class DeleteShipperCommandHandler : IRequestHandler<DeleteShipperCommand, IResponse>
        {
            private readonly IShipperRepository _shipperRepository;

            public DeleteShipperCommandHandler(IShipperRepository shipperRepository)
            {
                _shipperRepository = shipperRepository;
            }

            public async Task<IResponse> Handle(DeleteShipperCommand request, CancellationToken cancellationToken)
            {
                Shipper deletedShipper = _shipperRepository.Get(_=>_.ShipperId == request.ShipperId);

                _shipperRepository.Delete(deletedShipper);
                await _shipperRepository.SaveChangesAsync();

                return new Response<Shipper>(deletedShipper);
            }
        }
    }
}
