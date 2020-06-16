using System.ComponentModel.DataAnnotations;

namespace My_Expenses.ViewModels.ProductModels
{
    public class EditProductModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
