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
    public class GetRegionQuery : IRequest<IResponse>
    {
        public int RegionId { get; set; }

        public class GetRegionQueryHandler : IRequestHandler<GetRegionQuery, IResponse>
        {
            private readonly IRegionRepository _regionRepository;

            public GetRegionQueryHandler(IRegionRepository regionRepository)
            {
                _regionRepository = regionRepository;
            }
            public async Task<IResponse> Handle(GetRegionQuery request, CancellationToken cancellationToken)
            {
                var currentRegion = await _regionRepository.GetAsync(_=>_.RegionId == request.RegionId);

                return new Response<Region>(currentRegion);
            }
        }
    }
}
