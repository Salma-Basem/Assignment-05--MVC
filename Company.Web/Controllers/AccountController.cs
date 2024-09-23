using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Helper;
using System.Security.Cryptography.X509Certificates;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
           _signInManager = signInManager;
        }

        #region Sign up
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel input)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = input.Email.Split("@")[0],
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    IsActive = true

                };
                var result = await _userManager.CreateAsync(user, input.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }

                foreach (var item in result.Errors)
                    ModelState.AddModelError("", item.Description);
            }
            return View();
        }

        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(input.Email);
                if (user is not null)
                {
                    if (await _userManager.CheckPasswordAsync(user, input.Password))
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, input.Password,input.RememberMe, true);
                        if (result.Succeeded)
                            return RedirectToAction("Index", "Home");
                    }


                }
                ModelState.AddModelError("", "incorrect email or password");
                return View(input);
            }
            return View(input);
        }

        #endregion
        public new async Task<IActionResult> SignOut()
        {
            await  _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult ForgetPassword()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(input.Email);
                if(user is not null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var url = Url.Action("ResetPassword", "Account", new {Email= input.Email,Token = token},Request.Scheme);
                    var email = new Email
                    {
                      Body=url,
                      Subject="Reset Password",
                      To=input.Email
                    };
                    EmailSetting.SendEmail(email);
                    return RedirectToAction(nameof(CheckYouInbox));

                }
            }
            return View(input);
        }

        public IActionResult CheckYouInbox()
        {
            return View();
        }

        public IActionResult ResetPassword(string Email,string Token)
        {
            return View();
        }
        [HttpPost]

        public async Task <IActionResult> ResetPassword(ResetPasswordViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(input.Email);
                if (user is not null)
                {
                    var result = await _userManager.ResetPasswordAsync(user,input.Token,input.Password);
                    if (result.Succeeded)
                        return RedirectToAction(nameof(Login));
                    foreach (var item in result.Errors)
                        ModelState.AddModelError("", item.Description);
                }

             }
                return View(input);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}