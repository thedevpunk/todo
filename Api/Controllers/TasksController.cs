using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {

        private readonly TodoContext _context;

        public TasksController(TodoContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IEnumerable<Core.Entities.Task>> Get()
        {
            IEnumerable<Core.Entities.Task> tasks = await _context.Tasks.ToListAsync();

            return tasks;
        }
    }
}