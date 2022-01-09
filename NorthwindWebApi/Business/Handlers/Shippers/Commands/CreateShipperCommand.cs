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
    public class CreateShipperCommand : IRequest<IResponse>
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public class CreateShipperCommandHandlar : IRequestHandler<CreateShipperCommand, IResponse>
        {
            private readonly IShipperRepository _shipperRepository;

            public CreateShipperCommandHandlar(IShipperRepository shipperRepository)
            {
                _shipperRepository = shipperRepository;
            }
            public async Task<IResponse> Handle(CreateShipperCommand request, CancellationToken cancellationToken)
            {
               Shipper addedShipper = new Shipper();
               addedShipper.CompanyName = request.CompanyName;
               addedShipper.Phone = request.Phone;

                _shipperRepository.Add(addedShipper);
                await _shipperRepository.SaveChangesAsync();

                return new Response<Shipper>(addedShipper);
            }
        }
    }
}
