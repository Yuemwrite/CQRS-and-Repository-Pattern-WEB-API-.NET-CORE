using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Territories.Commands
{
    public class CreateTerritoryCommand : IRequest<IResponse>
    {
        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

        public class CreateTerritoryCommandHandler : IRequestHandler<CreateTerritoryCommand, IResponse>
        {
            private readonly ITerritoryRepository _territoryRepository;

            public CreateTerritoryCommandHandler(ITerritoryRepository territoryRepository)
            {
                _territoryRepository = territoryRepository;
            }
            public async Task<IResponse> Handle(CreateTerritoryCommand request, CancellationToken cancellationToken)
            {
                Territory addedTerritory = new Territory();
                addedTerritory.TerritoryId = request.TerritoryId;
                addedTerritory.TerritoryDescription = request.TerritoryDescription;
                addedTerritory.RegionId = request.RegionId;
                
                _territoryRepository.Add(addedTerritory);
                await _territoryRepository.SaveChangesAsync();

                return new Response<Territory>(addedTerritory);
            }
        }
    }
}
