using MediatR;

namespace Cqrs.Data.Command
{
    public sealed class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
