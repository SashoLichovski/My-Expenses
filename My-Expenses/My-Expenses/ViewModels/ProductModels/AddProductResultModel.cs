using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Expenses.ViewModels.ProductModels
{
    public class AddProductResultModel
    {
        public bool IsValid { get; set; }
        public string ResultMessage { get; set; }
        public string ProductName { get; set; }
        public int AmountLeft { get; set; }
        public int ProductPrice { get; set; }
    }
}
