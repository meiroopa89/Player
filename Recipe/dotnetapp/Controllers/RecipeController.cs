using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections;



namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController :  ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipes", new {id = recipe.id}, recipe);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes ()
        {
           return await _context.Recipes.ToListAsync();
        }
    }
}