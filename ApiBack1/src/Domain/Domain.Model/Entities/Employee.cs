using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Employee
    {
        public string? Id { get; private set; }
        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Country { get; private set; }
        public string Role { get; private set; }

        public Employee(string id, string name, string age, string country, string role)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Country = country;
            this.Role = role;
        }

    }
}
