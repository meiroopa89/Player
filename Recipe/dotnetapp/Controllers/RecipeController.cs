using System.Globalization;
using System.Runtime.CompilerServices;
using dotnetapp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RecipeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Recipe>> AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
           await _context.SaveChangesAsync();

           return CreatedAtAction("GetRecipes", new {id => recipe.id}, recipe);
        }

        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }
    }
}