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
        public MyExpensesContext Context { get; }
        public UserRepository(MyExpensesContext context)
        {
            Context = context;
        }

        public UserRepository()
        {
        }

        public User GetByUsername(string username)
        {
            return Context.Users.FirstOrDefault(x => x.Username == username);
        }

        public void Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }

        public User GetById(int userId)
        {
            return Context.Users.FirstOrDefault(x => x.Id == userId);
        }
    }
}
