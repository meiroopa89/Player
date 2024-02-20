using Microsoft.AspNetCore.Mvc;
using System.Linq;
using dotnetapp.Models;
using dotnetapp.Data;

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
        bool isUnique = !_dbContext.Gifts.Any(g => g.GiftType == giftType);

        if (!isUnique)
        {
            ModelState.AddModelError("GiftType", "Gift Type already exists.");
            return Json(false);
        }

        return Json(true);
    }
}
