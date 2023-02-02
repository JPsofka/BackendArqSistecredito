using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Employees
{
    public interface IEmployeeUseCase
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> SaveEmployee(Employee employee);
        Task<Employee> GetEmployeeAsync(string id);
        Task<Employee> UpdateEmployee(string id, Employee employee);
        Task DeleteEmployee(string id);
    }
}
