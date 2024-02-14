// using Microsoft.AspNetCore.Mvc;
// using dotnetapp.Models;
// using dotnetapp.Services;
// using Microsoft.Extensions.Configuration;


// namespace dotnetapp.Controllers
// {
//     [ApiController]
//     [Route("api/gift")]  // Assuming you want the endpoint to be "api/gift"
//     public class GiftController : ControllerBase
//     {
//         private readonly GiftService _giftService;

//         public GiftController(GiftService giftService)
//         {
//             _giftService = giftService;
//         }

//         [HttpPost]
//         public IActionResult addGift([FromBody] Gift gift)
//         {
//             var addedGift = _giftService.addGift(gift);

//             return CreatedAtAction(nameof(viewAllGifts), new { id = addedGift.GiftId }, addedGift);
//         }


//  [HttpGet]
// public IActionResult viewAllGifts()
// {
//     Console.WriteLine("gift controller");

//     var gifts = _giftService.viewAllGifts();

//     if (gifts != null)
//     {
//         return Ok(gifts);
//     }

//     // If gifts is null, return an empty list instead of NotFound
//     return Ok(new List<Gift>());
// }



//         [HttpPut("{id}")]
//         public IActionResult updateGift(long id, [FromBody] Gift updatedGift)
//         {
//             var editedGift = _giftService.updateGift(id, updatedGift);

//             if (editedGift != null)
//             {
//                 return Ok(editedGift);
//             }

//             return NotFound(new { Message = "Gift not found." });
//         }



//         [HttpDelete("{id}")]
//         public IActionResult deleteGift(long id)
//         {
//             var deletedGift = _giftService.deleteGift(id);

//             if (deletedGift != null)
//             {
//                 return Ok(deletedGift);
//             }

//             return NotFound(new { Message = "Gift not found." });
//         }


//     }
// }



//new
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Services;

[Route("api/[controller]")]
[ApiController]
public class GiftController : ControllerBase
{
    private readonly GiftService _giftService;

    public GiftController(GiftService giftService)
    {
        _giftService = giftService;
    }

    [HttpPost]
    public IActionResult AddGift([FromBody] Gift gift)
    {
        var addedGift = _giftService.AddGift(gift);
        return Ok(addedGift);
    }

    [HttpGet]
    public IActionResult GetAllGifts()
    {
        var allGifts = _giftService.GetAllGifts();
        return Ok(allGifts);
    }

    [HttpPut("{giftId}")]
    public IActionResult EditGift(long giftId, [FromBody] Gift updatedGift)
    {
        var editedGift = _giftService.EditGift(giftId, updatedGift);
        if (editedGift != null)
        {
            return Ok(editedGift);
        }
        return NotFound("Gift not found");
    }

    [HttpDelete("{giftId}")]
    public IActionResult DeleteGift(long giftId)
    {
        var deletedGift = _giftService.DeleteGift(giftId);
        if (deletedGift != null)
        {
            return Ok(deletedGift);
        }
        return NotFound("Gift not found");
    }
}
