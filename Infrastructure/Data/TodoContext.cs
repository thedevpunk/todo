using Core.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Infrastructure.Data
{
    public class TodoContext
    {
        private IMongoDatabase _database;

        public IMongoCollection<TodoTask> Tasks => _database.GetCollection<TodoTask>("task");

        public TodoContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("todo");
        }
    }
}