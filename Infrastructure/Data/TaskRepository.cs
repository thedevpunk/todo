using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoContext _context;

        public TaskRepository(TodoContext context)
        {
            _context = context;

        }

        public async Task<Core.Entities.Task> GetTaskByGuidAsync(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<IReadOnlyList<Core.Entities.Task>> GetTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }
    }
}