using Cqrs.Models;
using MediatR;

namespace Cqrs.Data
{
    public class GetEmployeeByIdQuery : IRequest <Employee>
    {
        public int Id { get; set; }
    }
}
