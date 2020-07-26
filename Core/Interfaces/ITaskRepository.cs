using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITaskRepository
    {
         Task<Core.Entities.Task> GetTaskByGuidAsync(Guid guid);

         Task<IReadOnlyList<Core.Entities.Task>> GetTasksAsync();
    }
}