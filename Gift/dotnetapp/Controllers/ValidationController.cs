using Microsoft.AspNetCore.Mvc;
using System.Linq;
using dotnetapp.Models;
using dotnetapp.Data;
using dotnetapp.Controllers;

namespace dotnetapp.Controllers
{
public class ValidationController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public ValidationController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [AcceptVerbs("Get", "Post")]
    public IActionResult IsGiftTypeUnique(string giftType)
    {
        var isUnique = !_dbContext.Gifts.Any(g => g.GiftType == giftType);
        return Json(isUnique);
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] Gift gift)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _dbContext.Gifts.Add(gift);
        _dbContext.SaveChanges();

        return Ok(gift);
    }
}
}
