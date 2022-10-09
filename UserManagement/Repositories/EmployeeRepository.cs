using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserManagement.Interfaces;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly IMongoCollection<Employee> _departmentCollection;

        public EmployeeRepository(IOptions<UserManagementDatabaseSettings> databaseSettings)
        {
            MongoClient mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _departmentCollection = mongoDatabase.GetCollection<Employee>("Employee");
        }
        public async Task<IEnumerable<Employee>> GetAll() =>
            await _departmentCollection.Find(_ => true).ToListAsync();

        public async Task<Employee> GetEmployeeById(string employeeId) =>
                await _departmentCollection.Find(item => item.Id == employeeId).FirstOrDefaultAsync();

        public async Task CreateEmployee(Employee employee) =>
                await _departmentCollection.InsertOneAsync(employee);

        public async Task UpdateEmployee(string employeeId, Employee employee) =>
                await _departmentCollection.ReplaceOneAsync<Employee>(item => item.Id == employeeId, employee);

        public async Task DeleteEmployee(string employeeId) =>
                await _departmentCollection.DeleteOneAsync<Employee>(item => item.Id == employeeId);
    }
}

