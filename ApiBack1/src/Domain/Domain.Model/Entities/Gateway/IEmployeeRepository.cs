using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities.Gateway
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> SaveEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeAsync(string id);
        Task<Employee> UpdateEmployee(string id, Employee employee);
        Task DeleteEmployee(string id); 
    }
}
