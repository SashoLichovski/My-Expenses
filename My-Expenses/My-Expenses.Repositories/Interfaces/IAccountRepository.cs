using My_Expenses.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Expenses.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccByUserId(int userId);
        void Update(Account account);
    }
}
