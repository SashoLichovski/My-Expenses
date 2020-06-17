using System;
using System.Collections.Generic;

namespace My_Expenses.Data
{
    public class Account
    {
        public int Id { get; set; }
        public int MainAccount { get; set; }
        public int SavingsAccount { get; set; }
        public int SpendingAccount { get; set; }
        public List<Product> Products { get; set; }
        public List<User> Users { get; set; }
        public List<Sale> Sales { get; set; }
        public DateTime DateCreated { get; set; }
    }
}