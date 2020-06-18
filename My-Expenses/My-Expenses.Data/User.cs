using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace My_Expenses.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        [Required]
        public string Role { get; set; }
        public DateTime DateCreated { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
