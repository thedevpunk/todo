using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITaskRepository
    {
         Task<TodoTask> GetTaskByGuidAsync(Guid guid);

         Task<IReadOnlyList<TodoTask>> GetTasksAsync();
    }
}