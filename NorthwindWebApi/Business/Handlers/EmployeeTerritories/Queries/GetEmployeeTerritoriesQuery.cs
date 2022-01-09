using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.EmployeeTerritories.Queries
{
    public class GetEmployeeTerritoriesQuery : IRequest<IResponse>
    {
        public class GetEmployeeTerritoriesQueryHandler : IRequestHandler<GetEmployeeTerritoriesQuery, IResponse>
        {
            private readonly IEmployeeTerritoryRepository _employeeTerritoriesRepository;

            public GetEmployeeTerritoriesQueryHandler(IEmployeeTerritoryRepository employeeTerritoriesRepository)
            {
                _employeeTerritoriesRepository = employeeTerritoriesRepository;
            }
            public async Task<IResponse> Handle(GetEmployeeTerritoriesQuery request, CancellationToken cancellationToken)
            {
                var employeeTerritories = await _employeeTerritoriesRepository.GetEmployeeTerritoriesList();

                return new Response<IEnumerable<EmployeeTerritoriesDto>>(employeeTerritories);
            }
        }
    }
}
