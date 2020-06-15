using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace My_Expenses.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Prize { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        public string Note { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
