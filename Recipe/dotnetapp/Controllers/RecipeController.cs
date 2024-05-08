using System.Threading.Tasks;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class RecipeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> 
    }
}