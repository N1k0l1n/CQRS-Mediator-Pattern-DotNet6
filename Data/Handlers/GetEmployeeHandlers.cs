using Cqrs.Models;
using Cqrs.Services;
using MediatR;

namespace Cqrs.Data.Handlers
{
    public sealed class GetEmployeeHandlers : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeHandlers(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken) 
        {
            return await _employeeRepository.GetEmployeeByIdAsync(request.Id);
        }
    }
}
