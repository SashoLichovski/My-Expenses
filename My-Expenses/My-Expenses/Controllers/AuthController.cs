using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Expenses.Helpers;
using My_Expenses.Services.Interfaces;
using My_Expenses.ViewModels.AuthModels;
using My_Expenses.ViewModels.UserModel;

namespace My_Expenses.Controllers
{
    public class AuthController : Controller
    {
        public IAuthService AuthService { get; }
        public AuthController(IAuthService authService)
        {
            AuthService = authService;
        }

        public IActionResult SignIn()
        {
            var model = new SignInModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var converted = ReverseModel.ToUser(model);
                var isValid = await AuthService.SignInAsync(converted, HttpContext);
                if (isValid)
                {
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("HomePage", "Product");
                }
                ModelState.AddModelError(string.Empty, "Wrong username or password");
                return View(model);
            }
            return View(model);
        }
        public IActionResult SignOut()
        {
            AuthService.SignOut(HttpContext);
            return RedirectToAction("SignIn");
        }
        public IActionResult Register()
        {
            var model = new RegisterModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                bool status = AuthService.Validate(registerModel.Username);
                if (status)
                {
                    var converted = ReverseModel.ToUser(registerModel);
                    AuthService.RegisterUser(converted);
                    return RedirectToAction("SuccessfulRegister");
                }
                ModelState.AddModelError(string.Empty, $"Username {registerModel.Username} is already taken");
                return View();
            }
            return View(registerModel);
        }
        [HttpPost]
        [Authorize(Policy = "Role")]
        public IActionResult RegisterEmployee(RegisterEmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                bool status = AuthService.Validate(model.Username);
                if (status)
                {
                    var accountId = int.Parse(User.FindFirst("AccountId").Value);
                    var converted = ReverseModel.ToUser(model);
                    AuthService.RegisterEmployee(converted, accountId);

                    return RedirectToAction("SuccessfulRegister");
                }
                ModelState.AddModelError(string.Empty, $"Username {model.Username} is already taken");
                return View();
            }
            return View(model);
        }
        public IActionResult SuccessfulRegister()
        {
            return View();
        }
    }
}