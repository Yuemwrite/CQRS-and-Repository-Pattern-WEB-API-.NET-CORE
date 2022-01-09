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
    public class CreateEmployeeCommand : IRequest<IResponse>
    {
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

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, IResponse>
        {
            private readonly IEmployeeRepository _employeeRepository;

            public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }
            public async Task<IResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                Employee addedEmployee = new Employee();
                addedEmployee.FirstName = request.FirstName;
                addedEmployee.LastName = request.LastName;
                addedEmployee.Title = request.Title;
                addedEmployee.TitleOfCourtesy = request.TitleOfCourtesy;
                addedEmployee.Address = request.Address;
                addedEmployee.City = request.City;
                addedEmployee.Region = request.Region;
                addedEmployee.PostalCode = request.PostalCode;
                addedEmployee.Country = request.Country;
                addedEmployee.HomePhone = request.HomePhone;
                addedEmployee.Extension = request.Extension;
                addedEmployee.ReportsTo = request.ReportsTo;

                _employeeRepository.Add(addedEmployee);
                await _employeeRepository.SaveChangesAsync();

                return new Response<Employee>(addedEmployee);
            }
        }

    }
}
