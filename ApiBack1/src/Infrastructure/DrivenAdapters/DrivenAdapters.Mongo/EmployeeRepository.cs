using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using DrivenAdapters.Mongo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivenAdapters.Mongo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMongoCollection<EmployeeEntity> _employeeCollection;

        public EmployeeRepository(IContext mongoDb)
        {
            _employeeCollection = mongoDb.EmployeeCollection;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            IAsyncCursor<EmployeeEntity> employeeEntity =  await _employeeCollection.FindAsync(Builders<EmployeeEntity>.Filter.Empty);

            List<Employee> employees = employeeEntity.ToEnumerable().Select(employeeEntity => employeeEntity.asEntity()).ToList();

            return employees;
        }

        public async Task<Employee> SaveEmployeeAsync(Employee employee)
        {
            EmployeeEntity employeeEntity = new(employee.Name, employee.Age, employee.Country, employee.Role);

            await _employeeCollection.InsertOneAsync(employeeEntity);

            return employeeEntity.asEntity();
        }

        public async Task<Employee> GetEmployeeAsync(string id)
        {
            IAsyncCursor<EmployeeEntity> employeeEntity = await _employeeCollection.FindAsync(employee => employee.Id==id);

            Employee employee = employeeEntity.FirstAsync().Result.asEntity();

            return employee;
        }

        public async Task<Employee> UpdateEmployee(string id, Employee employee)
        {
            EmployeeEntity employeeEntity = new(id, employee.Name, employee.Age, employee.Country, employee.Role);

            await _employeeCollection.FindOneAndReplaceAsync(employee => employee.Id ==id , employeeEntity);

            return employeeEntity.asEntity();
        }

        public async Task DeleteEmployee(string id)
        {
            await _employeeCollection.FindOneAndDeleteAsync(emp => emp.Id == id);
        }
    }
}
