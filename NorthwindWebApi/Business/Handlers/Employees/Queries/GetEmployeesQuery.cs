using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Employees.Queries;

public class GetEmployeesQuery : IRequest<IResponse>
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IResponse>
    {
        private readonly IEmployeeRepository _employeesRepository;

        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeesRepository = employeeRepository;
        }

        public async Task<IResponse> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeesRepository.GetListAsync();
            return new Response<IEnumerable<Employee>>(employees);
        }
    }
}
