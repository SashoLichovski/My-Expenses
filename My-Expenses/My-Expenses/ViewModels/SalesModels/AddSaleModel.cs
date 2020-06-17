using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Expenses.ViewModels.SalesModels
{
    public class AddSaleModel
    {
        [Required]
        public int DailySales { get; set; }
        public string Note { get; set; }
    }
}
