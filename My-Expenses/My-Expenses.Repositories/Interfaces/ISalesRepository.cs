using System;
using System.Collections.Generic;
using System.Text;
using My_Expenses.Data;

namespace My_Expenses.Repositories.Interfaces
{
    public interface ISalesRepository
    {
        void Add(Sale dbSale);
        void Populate();
        List<Sale> GetAll(int accountId);
        List<Sale> GetAllForUser(int accountId, string employeeUsername);
    }
}
