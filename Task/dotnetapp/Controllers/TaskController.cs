using System;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using dotnetapp.Models;

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

        public async Task<IActionResult> AddPost(Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }
    }
}