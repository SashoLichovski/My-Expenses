using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Expenses.Helpers;
using My_Expenses.Services.Interfaces;
using My_Expenses.ViewModels.AccountModels;

namespace My_Expenses.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult AccountOverview()
        {
            var accountId = int.Parse(User.FindFirst("AccountId").Value);
            var account = accountService.GetAccByAccountId(accountId);

            var converted = ConvertTo.AccountOverviewModel(account);
            return View(converted);
        }

        [HttpPost]
        [Authorize(Policy = "Role")]
        public IActionResult TransferToAccount(int amount, string toAccount)
        {
            var accountId = int.Parse(User.FindFirst("AccountId").Value);
            var account = accountService.GetAccByAccountId(accountId);
            var status = accountService.ValidateTransfer(amount, account);
            if (status.IsValid)
            {
                accountService.TransferToAccount(amount, account, toAccount);
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
        [Authorize(Policy = "Role")]
        public IActionResult AddToMain(int amount)
        {
            var accountId = int.Parse(User.FindFirst("AccountId").Value);
            var account = accountService.GetAccByAccountId(accountId);

            accountService.AddToMainAcc(amount, account);

            return RedirectToAction("AccountOverview");
        }
    }
}