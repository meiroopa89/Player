using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using dotnetapp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers
{
    [Route("api/[Controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult<Recipe>> AddPost (Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipe",new { id = Recipe.Id}, recipe);
        } 

        public async Task<IActionResult<IEnumerable<Recipe>>> GetRecipe()
        {
            return await _context.Recipes.ToListAsync();
        }
    }
}