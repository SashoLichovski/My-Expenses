using My_Expenses.Data;
using My_Expenses.ViewModels.AuthModels;
using My_Expenses.ViewModels.ProductModels;
using My_Expenses.ViewModels.SalesModels;
using My_Expenses.ViewModels.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Expenses.Helpers
{
    public static class ReverseModel
    {
        internal static User ToUser(SignInModel model)
        {
            return new User
            {
                Username = model.Username,
                Password = model.Password
            };
        }
        internal static User ToUser(RegisterModel model)
        {
            return new User
            {
                Username = model.Username,
                Password = model.Password,
                EmailAdress = model.EmailAdress
            };
        }
        internal static User ToUser(RegisterEmployeeModel model)
        {
            return new User
            {
                Username = model.Username,
                Password = model.Password,
                EmailAdress = model.EmailAdress
            };
        }

        internal static Sale ToSale(AddSaleModel model)
        {
            var sale = new Sale()
            {
                DailySalesAmount = model.DailySales
            };
            if (!string.IsNullOrEmpty(model.Note))
            {
                sale.Note = model.Note;
            }
            return sale;
        }

        public static Product ToProduct(AddProductModel model)
        {
            return new Product
            {
                Name = model.Name,
                Price = model.Price,
                Category = model.Category,
                Note = model.Note
            };
        }
        public static Product ToProduct(EditNoteModel model)
        {
            return new Product
            {
                Id = model.Id,
                Note = model.Note
            };
        }
    }
}
