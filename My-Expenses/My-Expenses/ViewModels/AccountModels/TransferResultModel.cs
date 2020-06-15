using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Expenses.ViewModels.AccountModels
{
    public class TransferResultModel
    {
        public bool IsValid { get; set; }
        public string ResultMessage { get; set; }
        public int AmountTransfered { get; set; }
        public int AmountLeft { get; set; }

    }
}
