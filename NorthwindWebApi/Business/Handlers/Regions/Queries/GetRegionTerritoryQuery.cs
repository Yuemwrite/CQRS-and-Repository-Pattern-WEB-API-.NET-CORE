using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Regions.Queries
{
    public class GetRegionTerritoryQuery : IRequest<IResponse>
    {
        public class GetRegionTerritryQueryHandler : IRequestHandler<GetRegionTerritoryQuery, IResponse>
        {
            private readonly IRegionRepository _regionRepository;

            public GetRegionTerritryQueryHandler(IRegionRepository regionRepository)
            {
                _regionRepository = regionRepository;
            }
            public async Task<IResponse> Handle(GetRegionTerritoryQuery request, CancellationToken cancellationToken)
            {
                var regionTerritories = await _regionRepository.RegionTerritoriesList();

                return new Response<IEnumerable<RegionWithTerritoriesDto>>(regionTerritories);
            }
        }
    }
}
