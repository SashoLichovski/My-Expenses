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

        public void AddToMainAcc(int amount, Account account)
        {
            account.MainAccount += amount;
            accountRepository.Update(account);
        }

        public Account GetAccByUserId(int userId)
        {
            return accountRepository.GetAccByUserId(userId);
        }

        public void SubtractSpendingAccount(int price, int userId)
        {
            var account = accountRepository.GetAccByUserId(userId);
            account.SpendingAccount -= price;
            accountRepository.Update(account);
        }

        public void TransferToAccount(int amount, Account account, string toAccount)
        {
            account.MainAccount -= amount;
            if (toAccount == "savings")
            {
                account.SavingsAccount += amount;
                accountRepository.Update(account);
            }
            else if (toAccount == "spending")
            {
                account.SpendingAccount += amount;
                accountRepository.Update(account);
            }
        }

        public AddProductStatus ValidateSpendingAccount(int price, int userId)
        {
            var status = new AddProductStatus();
            var account = accountRepository.GetAccByUserId(userId);
            if (account.SpendingAccount >= price)
            {
                account.SpendingAccount -= price;
                accountRepository.Update(account);
                status.AccountRemainingBalance = account.SpendingAccount;
                status.IsValid = true;
                status.ResultMessage = $"Product successfully added.";
            }
            else
            {
                status.AccountRemainingBalance = account.SpendingAccount;
                status.IsValid = false;
                status.ResultMessage = $"Adding product failed - Insufficient funds. Spending account balance: {account.SpendingAccount} | Product price: {price}";
            }
            return status;
        }

        public TransferStatus ValidateTransfer(int amount, Account account)
        {
            var model = new TransferStatus();
            if (account.MainAccount >= amount)
            {
                model.IsValid = true;
                model.ResultMessage = "Amount was successfully transfered";
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
