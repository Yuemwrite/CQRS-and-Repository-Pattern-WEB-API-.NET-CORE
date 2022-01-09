using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Territories.Queries
{
    public class GetTerritoriesQuery : IRequest<IResponse>
    {
        public class GetTerritoriesQueryHandler : IRequestHandler<GetTerritoriesQuery, IResponse>
        {
            private readonly ITerritoryRepository _territoryRepository;

            public GetTerritoriesQueryHandler(ITerritoryRepository territoryRepository)
            {
                _territoryRepository = territoryRepository;
            }
            public async Task<IResponse> Handle(GetTerritoriesQuery request, CancellationToken cancellationToken)
            {
                var territories = await _territoryRepository.GetListAsync();
                return new Response<IEnumerable<Territory>>(territories);
            }
        }
    }
}
