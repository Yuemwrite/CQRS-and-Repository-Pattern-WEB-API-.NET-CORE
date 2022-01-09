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
    public class GetShippersQuery : IRequest<IResponse>
    {
        public class GetShippersQueryHandler : IRequestHandler<GetShippersQuery, IResponse>
        {
            private readonly IShipperRepository _shipperRepository;

            public GetShippersQueryHandler(IShipperRepository shipperRepository)
            {
                _shipperRepository = shipperRepository;
            }
            public async Task<IResponse> Handle(GetShippersQuery request, CancellationToken cancellationToken)
            {
                var shippers = await _shipperRepository.GetListAsync();
                return new Response<IEnumerable<Shipper>>(shippers);
            }
        }
    }
}
