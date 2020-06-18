using System;
using System.Collections.Generic;
using System.Text;

namespace My_Expenses.Services.Dto.UserDtoModels
{
    public class UserOverviewData
    {
        public int Id { get; set; }
        public string EmployeeUsername { get; set; }
        public int TotalExpenses { get; set; }
        public int TotalDailySales { get; set; }
    }
}
