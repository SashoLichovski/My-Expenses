using System.ComponentModel.DataAnnotations;

namespace My_Expenses.ViewModels.ProductModels
{
    public class AddProductModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Category { get; set; }
        public string Note { get; set; }
    }
}
