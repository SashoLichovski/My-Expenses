using System;
using System.Collections.Generic;
using System.Text;

namespace My_Expenses.Services.Dto
{
    public class AddProductStatus
    {
        public bool IsValid { get; set; }
        public string ResultMessage { get; set; }
        public int AccountRemainingBalance { get; set; }
    }
}
