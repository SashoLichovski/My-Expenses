using My_Expenses.Data;
using My_Expenses.Repositories.Interfaces;
using My_Expenses.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace My_Expenses.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository salesRepository;
        private readonly IUserRepository userRepository;

        public SalesService(ISalesRepository salesRepository, IUserRepository userRepository)
        {
            this.salesRepository = salesRepository;
            this.userRepository = userRepository;
        }

        public void CreateSale(Sale sale, int userId, int accountId)
        {
            User user = userRepository.GetById(userId);
            var dbSale = new Sale()
            {
                DailySalesAmount = sale.DailySalesAmount,
                Note = sale.Note,
                EmployeeUsername = user.Username,
                DateCreated = DateTime.Now,
                AccountId = accountId
            };
            salesRepository.Add(dbSale);
        }

        public List<Sale> GetAll(int accountId)
        {
            return salesRepository.GetAll(accountId);
        }

        public List<Sale> GetAllForUser(int accountId, string employeeUsername)
        {
            return salesRepository.GetAllForUser(accountId, employeeUsername);
        }
    }
}
