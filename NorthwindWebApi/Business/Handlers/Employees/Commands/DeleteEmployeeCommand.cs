using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<IResponse>
    {
        public int EmployeeId { get; set; }

        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, IResponse>
        {
            private readonly IEmployeeRepository _employeeRepository;

            public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }
            public async Task<IResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var deletedEmployee = await _employeeRepository.GetAsync(_=>_.EmployeeId == request.EmployeeId);

                _employeeRepository.Delete(deletedEmployee);
                await _employeeRepository.SaveChangesAsync();

                return new Response<Employee>(deletedEmployee);
            }
        }
    }
}
