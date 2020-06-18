using My_Expenses.Data;
using My_Expenses.Repositories.Interfaces;
using My_Expenses.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Expenses.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IAccountRepository accountRepository;

        public UserService(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            this.userRepository = userRepository;
            this.accountRepository = accountRepository;
        }
        public bool Validate(string username)
        {
            var user = userRepository.GetByUsername(username);
            if (user == null)
            {
                return true;
            }
            return false;
        }
        public void RegisterUser(User user)
        {
            user.Role = "manager";
            var account = new Account()
            {
                DateCreated = DateTime.Now
            };
            accountRepository.AddAccount(account);
            var acc = accountRepository.GetLatest();
            user.AccountId = acc.Id;
            userRepository.Add(user);
        }
        public void RegisterEmployee(User user, int accountId)
        {
            user.Role = "employee";
            user.AccountId = accountId;
            userRepository.Add(user);
        }
    }
}
