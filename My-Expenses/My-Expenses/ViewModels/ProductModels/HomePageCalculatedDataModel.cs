using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Expenses.ViewModels.ProductModels
{
    public class HomePageCalculatedDataModel
    {
        public List<HomePageModel> Products { get; set; }
        public CalculatedDataModel Data { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> EmployeeUsernames { get; set; }
    }
}
