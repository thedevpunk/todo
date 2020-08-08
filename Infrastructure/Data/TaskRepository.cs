using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoContext _context;

        public TaskRepository(TodoContext context)
        {
            _context = context;

        }

        public async Task<TodoTask> GetTaskByGuidAsync(Guid id)
        {
            var filter = Builders<TodoTask>.Filter.Eq("Id", id);

            return await _context.Tasks.FindSync(filter).FirstAsync();
        }

        public async Task<IReadOnlyList<TodoTask>> GetTasksAsync()
        {
            return await _context.Tasks.FindSync(new BsonDocument()).ToListAsync();
        }
    }
}