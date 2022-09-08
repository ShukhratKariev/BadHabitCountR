using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Route("[controller]/[action]")]
[AllowAnonymous]
public class AccountController : Controller
{
    private readonly UserService _userService;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserService userService, SignInManager<User> signInManager)
    {
        _userService = userService;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp([FromForm] RegisterUserViewModel registerForm)
    {
        var user = new User()
        {
            UserName = registerForm.UserName,
        };
        await _userService.CreateAsync(user, registerForm.Password);

        await _signInManager.SignInAsync(user, true);
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn([FromForm] LoginUserViewModel registerForm)
    {
        var passwordSignInAsync = await _signInManager.PasswordSignInAsync(registerForm.UserName, registerForm.Password, true, false);
        if (passwordSignInAsync.Succeeded)
            return RedirectToAction("Index", "Home");
        return View();
    }
}