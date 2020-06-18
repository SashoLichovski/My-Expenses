using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Expenses.Helpers;
using My_Expenses.Services.Interfaces;
using My_Expenses.ViewModels.AuthModels;
using My_Expenses.ViewModels.UserModel;

namespace My_Expenses.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult RegisterEmployee()
        {
            return View();
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
                bool status = userService.Validate(registerModel.Username);
                if (status)
                {
                    var converted = ReverseModel.ToUser(registerModel);
                    userService.RegisterUser(converted);
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
                bool status = userService.Validate(model.Username);
                if (status)
                {
                    var accountId = int.Parse(User.FindFirst("AccountId").Value);
                    var converted = ReverseModel.ToUser(model);
                    userService.RegisterEmployee(converted, accountId);

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