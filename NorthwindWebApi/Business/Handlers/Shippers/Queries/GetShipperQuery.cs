using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Shippers.Queries
{
    public class GetShipperQuery : IRequest<IResponse>
    {
        public int ShipperId { get; set; }

        public class GetShipperQueryHandler : IRequestHandler<GetShipperQuery, IResponse>
        {
            private IShipperRepository _shipperRepository;

            public GetShipperQueryHandler(IShipperRepository shipperRepository)
            {
                _shipperRepository = shipperRepository;
            }
            public async Task<IResponse> Handle(GetShipperQuery request, CancellationToken cancellationToken)
            {
                var currentShipper = await _shipperRepository.GetAsync(_=>_.ShipperId == request.ShipperId);

                return new Response<Shipper>(currentShipper);
            }
        }
    }
}
