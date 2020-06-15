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

        public Account GetAccByUserId(int userId)
        {
            return context.Accounts.FirstOrDefault(x => x.UserId == userId);
        }

        public void Update(Account account)
        {
            context.Accounts.Update(account);
            context.SaveChanges();
        }
    }
}
