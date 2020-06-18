using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Expenses.ViewModels.UserModel
{
    public class UserOverviewDataModel
    {
        public int Id { get; set; }
        public string EmployeeUsername { get; set; }
        public int TotalExpenses { get; set; }
        public int TotalDailySales { get; set; }
        public DateTime FirstSale { get; set; }
    }
}
