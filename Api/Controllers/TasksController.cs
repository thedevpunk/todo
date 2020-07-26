using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private readonly ITaskRepository _taskRepo;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ITaskRepository taskRepo, ILogger<TasksController> logger)
        {
            _logger = logger;
            _taskRepo = taskRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Core.Entities.Task>> GetTasks()
        {
            IEnumerable<Core.Entities.Task> tasks = await _taskRepo.GetTasksAsync();

            return tasks;
        }

        [HttpGet("{id}")]
        public async Task<Core.Entities.Task> GetTask(Guid id)
        {
            Core.Entities.Task task = await _taskRepo.GetTaskByGuidAsync(id);

            return task;
        }
    }
}