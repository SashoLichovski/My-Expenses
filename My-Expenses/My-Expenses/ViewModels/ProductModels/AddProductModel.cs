using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Expenses.ViewModels.ProductModels
{
    public class AddProductModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Prize { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
