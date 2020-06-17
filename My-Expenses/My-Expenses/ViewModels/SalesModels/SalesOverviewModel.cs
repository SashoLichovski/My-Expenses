using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Expenses.ViewModels.SalesModels
{
    public class SalesOverviewModel
    {
        public int DailySalesAmount { get; set; }
        public string EmployeeUsername { get; set; }
        public string Note { get; set; }
        public string DateCreated { get; set; }
    }
}
