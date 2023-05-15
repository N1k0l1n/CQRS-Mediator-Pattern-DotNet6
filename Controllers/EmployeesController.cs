using Cqrs.Data;
using Cqrs.Data.Command;
using Cqrs.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //EMPLOYEE LIST
        [HttpGet]
        public async Task <List<Employee>> EmployeeList()
        {
            var employeeList = await _mediator.Send(new GetEmployeeListQuery());
            return employeeList;
        }

        //GET BY ID
        [HttpGet("{id}")]
        public async Task<Employee> EmployeeById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery() {Id =id });
            return employee;
        }

        //ADD EMPLOYEE
        [HttpPost]
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeReturn = await _mediator.Send(new CreateEmployeeCommand(
                employee.Name, employee.Address, employee.Email, employee.Phone));
            return employeeReturn;
        }


        //UPDATE EMPLOYEE
        [HttpPut]
        public async Task<int> UpdateEmployee (Employee employee)
        {
            var employeeReturn = await _mediator.Send(new UpdateEmployeeCommand(employee.Id,
                employee.Name, employee.Address, employee.Email, employee.Phone));
            return employeeReturn;
        }

        //DELETE EMPLOYEE
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await _mediator.Send(new DeleteEmployeeCommand() { Id =id}); 
        }

    }
}
