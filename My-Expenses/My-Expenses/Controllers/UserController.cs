using System;
using Microsoft.AspNetCore.Mvc;

namespace My_Expenses.Controllers
{
    public class UserController : Controller
    {
        public IActionResult RegisterNewEmployee()
        {
            return View();
        }
    }
}