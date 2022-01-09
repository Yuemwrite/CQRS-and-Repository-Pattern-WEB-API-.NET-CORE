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
    public class UpdateEmployeeCommand : IRequest<IResponse>
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }

        public string Address { get; set; }
        public string City { get; set; }

        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public int ReportsTo { get; set; }

        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, IResponse>
        {
            private IEmployeeRepository _employeeRepository;

            public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }
            public async Task<IResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var updatedEmployee =  _employeeRepository.Get(_=>_.EmployeeId == request.EmployeeId);
                updatedEmployee.FirstName = request.FirstName;
                updatedEmployee.LastName = request.LastName;
                updatedEmployee.Title = request.Title;
                updatedEmployee.TitleOfCourtesy = request.TitleOfCourtesy;
                updatedEmployee.Address = request.Address;
                updatedEmployee.City = request.City;
                updatedEmployee.Region = request.Region;
                updatedEmployee.PostalCode = request.PostalCode;
                updatedEmployee.Country = request.Country;
                updatedEmployee.HomePhone = request.HomePhone;
                updatedEmployee.Extension = request.Extension;
                updatedEmployee.ReportsTo = request.ReportsTo;


                _employeeRepository.Update(updatedEmployee);
                await _employeeRepository.SaveChangesAsync();
                return new Response<Employee>(updatedEmployee);
            }
        }
    }
}
