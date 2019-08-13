using AspNetCodeAcademyFinal.Models;
using DAL.Domian.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCodeAcademyFinal.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            await HttpContext.SignOutAsync();

            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind] LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var User = DB.UserRepository.GetByEmail(loginModel.Email);
                if (User !=null & User.Password == loginModel.Password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, User.Email),
                        new Claim(ClaimTypes.Role,User.Role.Name)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    return Redirect(returnUrl ?? "/");
                }
                else
                {
                    ViewBag.Result = "Login Failed.Please enter correct credentials";
                    return View();
                }
            }
            else
                return View();

        }
        [Authorize]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
