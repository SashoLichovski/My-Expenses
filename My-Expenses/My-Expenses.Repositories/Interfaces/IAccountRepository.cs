using My_Expenses.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Expenses.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccByAccountId(int accountId);
        void Update(Account account);
        void AddAccount(Account account);
        Account GetLatest();
    }
}
