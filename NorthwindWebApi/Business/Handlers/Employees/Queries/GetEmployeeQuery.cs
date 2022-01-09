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

public class GetEmployeeQuery : IRequest<IResponse>
{
    public int EmployeeId { get; set; }

    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, IResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IResponse> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var currentEmployee = await _employeeRepository.GetAsync(_=>_.EmployeeId == request.EmployeeId);

            return new Response<Employee>(currentEmployee);
        }
    }
}
