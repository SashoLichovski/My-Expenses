using System;
using System.Collections.Generic;
using My_Expenses.Data;

namespace My_Expenses.Services.Interfaces
{
    public interface ISalesService
    {
        void CreateSale(Sale sale, int userId, int accountId);
        List<Sale> GetAll(int accountId);
        List<Sale> GetAllForUser(int accountId, string employeeUsername);
    }
}
