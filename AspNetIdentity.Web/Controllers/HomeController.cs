using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetIdentity.Web.Models;
using Microsoft.AspNetCore.Identity;
using AspNetIdentity.Web.ViewModels;

namespace AspNetIdentity.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Signup()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Signup(SignupViewModel request)
    {

        if (!ModelState.IsValid)
        {
            return View();
        }

        var identityResult = await _userManager.CreateAsync(new()
        {
            UserName = request.Username,
            Email = request.Email,
            PhoneNumber = request.Phone
        }, request.Password);

        

        if (identityResult.Succeeded)
        {
            ViewBag.SuccessMessage = "User has been created successfully.";
            return View();
        }

        foreach (var error in identityResult.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }



        return View();
    }

    public IActionResult SignIn()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel request, string? returnUrl=null)
    {
        returnUrl = returnUrl ?? Url.Action("Index", "Home");
        var getUser = await _userManager.FindByEmailAsync(request.Email!);

        if (getUser == null)
        {
            return View();
        }

        var signInResult = await _signInManager.PasswordSignInAsync(getUser.UserName!, request.Password!, request.RememberMe, true);
        if (signInResult.Succeeded)
        {
            return Redirect(returnUrl!);
        }

        ModelState.AddModelError(string.Empty, "Email or password is wrong");

        return View();
    }
    
    public async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction(nameof(Index));


    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

