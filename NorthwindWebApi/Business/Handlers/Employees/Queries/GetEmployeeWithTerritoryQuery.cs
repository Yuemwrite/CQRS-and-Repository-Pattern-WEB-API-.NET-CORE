using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Employees.Queries
{
    public class GetEmployeeWithTerritoryQuery : IRequest<IResponse>
    {
        public class GetEmployeeWithTerritoryQueryHandler : IRequestHandler<GetEmployeeWithTerritoryQuery, IResponse>
        {
            private readonly IEmployeeTerritoryRepository _employeeRepository;

            public GetEmployeeWithTerritoryQueryHandler(IEmployeeTerritoryRepository employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }
            public async Task<IResponse> Handle(GetEmployeeWithTerritoryQuery request, CancellationToken cancellationToken)
            {
                var employeeTerritories = await _employeeRepository.GetTerritoriesWithEmployeeList();

                return new Response<IEnumerable<TerritoriesEmployeeDto>>(employeeTerritories);
            }
        }
    }
}
