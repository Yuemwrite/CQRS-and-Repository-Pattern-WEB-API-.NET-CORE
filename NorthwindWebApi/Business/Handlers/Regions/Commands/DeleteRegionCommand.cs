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
    public class DeleteRegionCommand : IRequest<IResponse>
    {
        public int RegionId { get; set; }

        public class DeleteRegionCommandHandler : IRequestHandler<DeleteRegionCommand, IResponse>
        {
            private readonly IRegionRepository _regionRepository;

            public DeleteRegionCommandHandler(IRegionRepository regionRepository)
            {
                _regionRepository = regionRepository;
            }
            public async Task<IResponse> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
            {
                var deletedRegion = await _regionRepository.GetAsync(_=>_.RegionId == request.RegionId);

                _regionRepository.Delete(deletedRegion);
                await _regionRepository.SaveChangesAsync();

                return new Response<Region>(deletedRegion);
            }
        }
    }
}
