using My_Expenses.Data;
using My_Expenses.Services.Dto.UserDtoModels;
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
        List<User> GetAllEmployees(int accountId);
        List<UserOverviewData> EmployeeOverviewData(List<Sale> sales, List<Product> products);
    }
}
