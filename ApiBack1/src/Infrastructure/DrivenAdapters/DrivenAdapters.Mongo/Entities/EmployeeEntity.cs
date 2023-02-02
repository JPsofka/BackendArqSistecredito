using Domain.Model.Entities;
using DrivenAdapters.Mongo.Entities.Base;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivenAdapters.Mongo.Entities
{
    public class EmployeeEntity : EntityBase, IDomainEntity<Employee>
    {
        [BsonElement(elementName:"name")]
        public string Name { get; private set; }

        [BsonElement(elementName: "age")]
        public string Age { get; private set; }

        [BsonElement(elementName: "country")]
        public string Country { get; private set; }

        [BsonElement(elementName: "role")]
        public string Role { get; private set; }

        public EmployeeEntity(string name, string age, string country, string role)
        {
            Name = name;
            Age = age;
            Country = country;
            Role = role;
        }

        public EmployeeEntity(string id, string name, string age, string country, string role)
        {
            Id = id;
            Name = name;
            Age = age;
            Country = country;
            Role = role;
        }


        public Employee asEntity()
        {
            return new(Id, Name, Age, Country, Role);
        }
    }
}
