using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using My_Expenses.Helpers;
using My_Expenses.Services.Interfaces;
using My_Expenses.ViewModels.SalesModels;

namespace My_Expenses.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISalesService salesService;
        private readonly IAccountService accountService;

        public SalesController(ISalesService salesService, IAccountService accountService)
        {
            this.salesService = salesService;
            this.accountService = accountService;
        }
        public IActionResult AddSale()
        {
            var model = new AddSaleModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddSale(AddSaleModel model)
        {
            if (ModelState.IsValid)
            {
                var sale = ReverseModel.ToSale(model);
                var userId = int.Parse(User.FindFirst("Id").Value);
                var accountId = int.Parse(User.FindFirst("accountId").Value);

                accountService.AddSalesToMainAccount(model.DailySales, accountId);

                salesService.CreateSale(sale, userId, accountId);
                return RedirectToAction("HomePage", "Product");
            }
            return View(model);
        }

        public IActionResult SalesOverview()
        {
            var accountId = int.Parse(User.FindFirst("accountId").Value);
            var EmployeeUsername = User.Identity.Name;
            var salesList = salesService.GetAllForUser(accountId, EmployeeUsername);
            var convertedList = new List<SalesOverviewModel>();
            foreach (var s in salesList)
            {
                convertedList.Add(ConvertTo.SalesOverviewModel(s));
            }
            return View(convertedList);
        }
    }
}