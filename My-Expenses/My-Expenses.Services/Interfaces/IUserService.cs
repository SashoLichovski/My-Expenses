using My_Expenses.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Expenses.Services.Interfaces
{
    public interface IUserService
    {
        bool Validate(string username);
        void RegisterUser(User user);
        void RegisterEmployee(User user, int accountId);
    }
}
