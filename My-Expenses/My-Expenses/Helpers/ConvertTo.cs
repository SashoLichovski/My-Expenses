using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Expenses.Data;
using My_Expenses.ViewModels.ProductModels;

namespace My_Expenses.Helpers
{
    public static class ConvertTo
    {
        internal static HomePageModel ToHomePageModel(Product product)
        {
            return new HomePageModel
            {
                Id = product.Id,
                Name = product.Name,
                Prize = product.Prize,
                DateCreated = product.DateAdded.ToString("dddd, MMMM dd, yyyy"),
                Category = product.Category
            };
        }
    }
}
