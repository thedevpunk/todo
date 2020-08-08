using Core.Entities;
using MongoDB.Driver;

namespace Infrastructure.Data
{
    public class TodoContext
    {
        private IMongoDatabase _database;

        public TodoContext(string connectionString)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("todo");
        }

        public IMongoCollection<Item> Items => _database.GetCollection<Item>("items");
    }
}