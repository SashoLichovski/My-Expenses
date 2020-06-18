using Microsoft.EntityFrameworkCore;
using My_Expenses.Data;
using My_Expenses.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My_Expenses.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyExpensesContext context;

        public UserRepository(MyExpensesContext context)
        {
            this.context = context;
        }

        public User GetByUsername(string username)
        {
            return context.Users.FirstOrDefault(x => x.Username == username);
        }

        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User GetById(int userId)
        {
            return context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public List<User> GettAllEmployees(int accountId)
        {
            return context.Users.Where(x => x.AccountId == accountId && x.Role != "manager")
                .ToList();
        }
    }
}
