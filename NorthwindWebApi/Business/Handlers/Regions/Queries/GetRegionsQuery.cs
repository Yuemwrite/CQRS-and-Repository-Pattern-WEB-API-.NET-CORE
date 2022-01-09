using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Regions.Queries
{
    public class GetRegionsQuery : IRequest<IResponse>
    {
        public class GetRegionsQueryHandler : IRequestHandler<GetRegionsQuery, IResponse>
        {
            private IRegionRepository _regionRepository;

            public GetRegionsQueryHandler(IRegionRepository regionRepository)
            {
                _regionRepository = regionRepository;
            }

            public async Task<IResponse> Handle(GetRegionsQuery request, CancellationToken cancellationToken)
            {
                var regions = await _regionRepository.GetListAsync();
                return new Response<IEnumerable<Region>>(regions);
            }
        }
    }
}
