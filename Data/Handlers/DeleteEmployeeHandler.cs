using Cqrs.Data.Command;
using Cqrs.Services;
using MediatR;
using NuGet.Protocol.Plugins;

namespace Cqrs.Data.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (employee is null) return default;
            return await _employeeRepository.DeleteEmployeeAsync(request.Id);
        }
    }
}
