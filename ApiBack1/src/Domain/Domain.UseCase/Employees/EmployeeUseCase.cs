using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Employees
{
    public class EmployeeUseCase : IEmployeeUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }

        public async Task<Employee> SaveEmployee(Employee employee)
        {
            return await _employeeRepository.SaveEmployeeAsync(employee);
        }

        public async Task<Employee> GetEmployeeAsync(string id)
        {
            return await _employeeRepository.GetEmployeeAsync(id);
        }

        public async Task<Employee> UpdateEmployee(string id, Employee employee)
        {
            return await _employeeRepository.UpdateEmployee(id, employee);
        }

        public async Task DeleteEmployee(string id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }

    }
}
