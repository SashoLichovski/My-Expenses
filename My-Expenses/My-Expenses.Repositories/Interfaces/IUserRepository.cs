﻿using My_Expenses.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Expenses.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
        void Add(User user);
        User GetById(int userId);
        List<User> GettAllEmployees(int accountId);
    }
}
