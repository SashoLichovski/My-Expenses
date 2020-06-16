using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using My_Expenses.Helpers;
using My_Expenses.Services.Interfaces;
using My_Expenses.ViewModels.AccountModels;

namespace My_Expenses.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult AccountOverview()
        {
            var userId = int.Parse(User.FindFirst("Id").Value);
            var account = accountService.GetAccByUserId(userId);

            var converted = ConvertTo.AccountOverviewModel(account);
            return View(converted);
        }

        [HttpPost]
        public IActionResult TransferToSavings(int amount)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);
            var account = accountService.GetAccByUserId(userId);
            var status = accountService.ValidateTransfer(amount, account);
            if (status.IsValid)
            {
                accountService.TransferToSavings(amount, account);
                var statusModel = ConvertTo.TransferResultModel(status,amount,account.MainAccount);
                return RedirectToAction("TransferResult", statusModel);
            }
            else
            {
                var statusModel = ConvertTo.TransferResultModel(status, amount, account.MainAccount);
                return RedirectToAction("TransferResult", statusModel);
            }
        }
        
        public IActionResult TransferResult(TransferResultModel result)
        {
            return View(result);
        }
    }
}