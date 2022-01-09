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
    public class UpdateRegionCommand : IRequest<IResponse>
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public class UpdateRegionCommandHandler : IRequestHandler<UpdateRegionCommand, IResponse>
        {
            private readonly IRegionRepository _regionRepository;

            public UpdateRegionCommandHandler(IRegionRepository regionRepository)
            {
                _regionRepository = regionRepository;
            }
            public async Task<IResponse> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
            {
                var updatedRegion = _regionRepository.Get(_=>_.RegionId == request.RegionId);
                updatedRegion.RegionDescription = request.RegionDescription;

                _regionRepository.Update(updatedRegion);
                await _regionRepository.SaveChangesAsync();
                return new Response<Region>(updatedRegion);

            }
        }
    }
}
