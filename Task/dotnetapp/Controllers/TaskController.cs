using System;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dotnetapp.Controllers
{
    [Route("api/[Controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult<Task>> AddPost(Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction ("GetTask", new {id = task.id}, task);
        }
    }
}