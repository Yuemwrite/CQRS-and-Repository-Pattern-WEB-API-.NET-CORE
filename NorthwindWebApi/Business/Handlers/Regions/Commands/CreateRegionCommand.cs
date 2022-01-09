using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Regions.Commands
{
    public class CreateRegionCommand : IRequest<IResponse>
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public class CreateRegionCommandHandler : IRequestHandler<CreateRegionCommand, IResponse>
        {
            private readonly IRegionRepository _regionRepository;

            public CreateRegionCommandHandler(IRegionRepository regionRepository)
            {
                _regionRepository = regionRepository;
            }
            public async Task<IResponse> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
            {
                Region addedRegion = new Region();
                addedRegion.RegionId = request.RegionId;
                addedRegion.RegionDescription = request.RegionDescription;

                _regionRepository.Add(addedRegion);
                await _regionRepository.SaveChangesAsync();

                return new Response<Region>(addedRegion);
            }
        }
    }
}
