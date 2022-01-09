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
    public class GetTerritoryQuery : IRequest<IResponse>
    {
        public string TerritoryId { get; set; }

        public class GetTerritoryQueryHandler : IRequestHandler<GetTerritoryQuery, IResponse>
        {
            private readonly ITerritoryRepository _territoryRepository;

            public GetTerritoryQueryHandler(ITerritoryRepository territoryRepository)
            {
                _territoryRepository = territoryRepository;
            }

            public async Task<IResponse> Handle(GetTerritoryQuery request, CancellationToken cancellationToken)
            {
                var currentTerritory = await _territoryRepository.GetAsync(_=>_.TerritoryId == request.TerritoryId);

                return new Response<Territory>(currentTerritory);
            }
        }
    }
}
