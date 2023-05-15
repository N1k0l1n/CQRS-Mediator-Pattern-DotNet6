using Cqrs.Data.Command;
using Cqrs.Models;
using Cqrs.Services;
using MediatR;

namespace Cqrs.Data.Handlers
{
    public sealed class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle (CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee emp = new Employee
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                Phone = request.Phone
            };
            return await _employeeRepository.AddEmployeeAsync(emp);
        }
    }
}
