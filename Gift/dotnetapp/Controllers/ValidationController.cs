using Microsoft.AspNetCore.Mvc;
using System.Linq;
using dotnetapp.Models;

public class ValidationController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public ValidationController(YourDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [AcceptVerbs("Get", "Post")]
    public IActionResult IsGiftTypeUnique(string giftType)
    {
        var isUnique = !_dbContext.Gifts.Any(g => g.GiftType == giftType);
        return Json(isUnique);
    }
}
