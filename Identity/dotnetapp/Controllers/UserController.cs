// UserController.cs

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class UserController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET: /User/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: /User/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Profile");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    // GET: /User/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: /User/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Profile");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        return View(model);
    }

    // GET: /User/Profile
    public IActionResult Profile()
    {
        var user = _userManager.GetUserAsync(User).Result;

        if (user != null)
        {
            if (int.TryParse(user.Id, out int userId))
            {
                var profileModel = new UserModel
                {
                    UserID = userId,
                    UserName = user.UserName,
                    Email = user.Email
                };

                return View(profileModel);
            }
            else
            {
                // Handle the case where user.Id is not a valid integer
                // You may set a default value or take appropriate action
                return View("Error");
            }
        }
        else
        {
            // Handle the case where user is null
            // You may redirect to a login page or take appropriate action
            return RedirectToAction("Login");
        }
    }


}
