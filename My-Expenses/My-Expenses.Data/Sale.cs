using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My_Expenses.Data
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DailySalesAmount { get; set; }
        public string EmployeeUsername { get; set; }
        public string Note { get; set; }
        public DateTime DateCreated { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }

    }
}
