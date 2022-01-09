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
    public class UpdateShipperCommand : IRequest<IResponse>
    {
        public int ShipperId { get; set; }

        public string CompanyName { get; set; }
        public string Phone { get; set; }

        

        public class UpdateShipperCommandHandler : IRequestHandler<UpdateShipperCommand, IResponse>
        {
            private readonly IShipperRepository _shipperRepository;
            public UpdateShipperCommandHandler(IShipperRepository shipperRepository)
            {
                _shipperRepository = shipperRepository;
            }
            public async Task<IResponse> Handle(UpdateShipperCommand request, CancellationToken cancellationToken)
            {
                Shipper updateShipper = _shipperRepository.Get(_=>_.ShipperId == request.ShipperId);
                updateShipper.CompanyName = request.CompanyName;
                updateShipper.Phone = request.Phone;

                _shipperRepository.Update(updateShipper);
                await _shipperRepository.SaveChangesAsync();

                return new Response<Shipper>(updateShipper);
            }
        }
    }
}
