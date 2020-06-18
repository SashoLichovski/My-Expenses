using My_Expenses.Data;
using My_Expenses.Repositories.Interfaces;
using My_Expenses.Services.Dto.UserDtoModels;
using My_Expenses.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            user.DateCreated = DateTime.Now;
            userRepository.Add(user);
        }
        public void RegisterEmployee(User user, int accountId)
        {
            user.Role = "employee";
            user.AccountId = accountId;
            user.DateCreated = DateTime.Now;
            userRepository.Add(user);
        }

        public List<User> GetAllEmployees(int accountId)
        {
            return userRepository.GettAllEmployees(accountId);
        }

        public List<UserOverviewData> EmployeeOverviewData(List<Sale> sales, List<Product> products)
        {
            var users = userRepository.GettAllEmployees(products[0].AccountId);
            var list = new List<UserOverviewData>();
            foreach (var user in users)
            {
                var userData = new UserOverviewData();
                userData.EmployeeUsername = user.Username;
                userData.Id = user.Id;
                userData.FirstSale = user.DateCreated;

                foreach (var sale in sales)
                {
                    if (sale.EmployeeUsername == user.Username)
                    {
                        userData.TotalDailySales += sale.DailySalesAmount;
                    }
                }

                foreach (var product in products)
                {
                    if (product.BoughtBy == user.Username)
                    {
                        userData.TotalExpenses += product.Price;
                    }
                }

                list.Add(userData);
            }
            return list;
        }
    }
}
