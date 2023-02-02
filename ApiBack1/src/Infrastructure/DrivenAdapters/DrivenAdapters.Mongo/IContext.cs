﻿using DrivenAdapters.Mongo.Entities;
using MongoDB.Driver;

namespace DrivenAdapters.Mongo
{
    /// <summary>
    /// Interfaz Mongo context contract.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Colleccion de Tipo Contrato
        /// </summary>
        IMongoCollection<EmployeeEntity> EmployeeCollection { get; }
    }
}