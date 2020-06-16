using My_Expenses.Data;
using My_Expenses.Repositories.Interfaces;
using My_Expenses.Services.Dto;
using My_Expenses.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Expenses.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Account GetAccByUserId(int userId)
        {
            return accountRepository.GetAccByUserId(userId);
        }

        public void TransferToSavings(int amount, Account account)
        {
            account.MainAccount -= amount;
            account.SavingsAccount += amount;
            accountRepository.Update(account);
        }

        public TransactionStatus ValidateTransfer(int amount, Account account)
        {
            var model = new TransactionStatus();
            if (account.MainAccount >= amount)
            {
                model.IsValid = true;
                model.ResultMessage = "Amount was successfully transfered to savings account";
            }
            else
            {
                model.IsValid = false;
                model.ResultMessage = "Transfer denied - Insufficient funds. Please add to main account first";
            }
            return model;
        }
    }
}
