using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Expenses.ViewModels.AccountModels
{
    public class AccountOverviewModel
    {
        public int Id { get; set; }
        public int MainAccount { get; set; }
        public int SavingsAccount { get; set; }
    }
}
