using System;
using System.ComponentModel.DataAnnotations;

namespace My_Expenses.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        public string Note { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }


        public string BoughtBy { get; set; }

    }
}
