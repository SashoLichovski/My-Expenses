using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Expenses.Data;
using My_Expenses.Services.Dto;
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
                Category = product.Category,
            };
        }
        internal static EditProductModel EditProductModel(Product product)
        {
            return new EditProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Prize = product.Prize,
                Category = product.Category
            };
        }
        internal static CalculatedDataModel CalculatedDataModel(CalculatedData model)
        {
            return new CalculatedDataModel
            {
                TotalAmount = model.TotalAmount,
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            };
        }
    }
}
