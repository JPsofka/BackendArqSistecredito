using Domain.Model.Entities;
using Domain.Model.Interfaces;
using Domain.UseCase.Employees;
using EntryPoints.ReactiveWeb.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EntryPoints.ReactiveWeb.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class EmployeeController : AppControllerBase<EmployeeController>
    {
        private readonly IEmployeeUseCase _employeeUseCase;
        public EmployeeController(IEmployeeUseCase employeeUseCase, IManageEventsUseCase eventsService) : base(eventsService)
        {
            _employeeUseCase = employeeUseCase;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployees()
        {
            return await HandleRequest(
                async () =>
                {
                    return await _employeeUseCase.GetEmployees();
                }, "");
        }

        [HttpPost]
        public async Task<IActionResult> SaveEmployee(Employee employee)
        {
            return await HandleRequest(
                async () =>
                {
                    return await _employeeUseCase.SaveEmployee(employee);
                }, "");
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetEmployee(string id)
        {
            return await HandleRequest(
                async () =>
                {
                    return await _employeeUseCase.GetEmployeeAsync(id);
                }, "");
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateEmployee(string id, Employee employee)
        {
            return await HandleRequest(
                async () =>
                {
                    return await _employeeUseCase.UpdateEmployee(id, employee);
                }, "");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Deleteemployee(string id)
        {
            return await HandleRequest(
                async () =>
                {
                    await _employeeUseCase.DeleteEmployee(id);
                    return NoContent();
                }, "");
        }


    }
}
