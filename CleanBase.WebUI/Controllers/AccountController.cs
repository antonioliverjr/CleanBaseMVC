using CleanBase.Domain.Account;
using CleanBase.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanBase.WebUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticate;
        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var result = await _authenticate.Authenticate(login.Email, login.Password);

            if (result)
            {
                if (string.IsNullOrEmpty(login.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(login.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao authenticar o usuário.");
                return View(login);
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            var result = await _authenticate.Register(register.Email, register.Password);
            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Erro ao registrar o usuário.");
                return View(register);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return Redirect("/Account/Login");
        }
    }
}
