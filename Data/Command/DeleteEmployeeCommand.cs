using MediatR;

namespace Cqrs.Data.Command
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
