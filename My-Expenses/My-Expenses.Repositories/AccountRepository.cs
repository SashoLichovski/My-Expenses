using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using My_Expenses.Data;
using My_Expenses.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My_Expenses.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyExpensesContext context;

        public AccountRepository(MyExpensesContext context)
        {
            this.context = context;
        }

        public void AddAccount(Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
        }

        public Account GetAccByAccountId(int accountId)
        {
            return context.Accounts.FirstOrDefault(x => x.Id == accountId);
        }

        public Account GetLatest()
        {
            var acc = context.Accounts.OrderByDescending(x => x.DateCreated).Take(1).ToList();
            return acc[0];
        }

        public void Update(Account account)
        {
            context.Accounts.Update(account);
            context.SaveChanges();
        }
    }
}
