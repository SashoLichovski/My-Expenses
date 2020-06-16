using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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