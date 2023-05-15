using Cqrs.Models;
using MediatR;

namespace Cqrs.Data
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>
    {
    }
}
