using My_Expenses.Data;
using My_Expenses.ViewModels.AuthModels;
using My_Expenses.ViewModels.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Expenses.Helpers
{
    public static class ReverseModel
    {
        public static User ToUser(SignInModel model)
        {
            return new User
            {
                Username = model.Username,
                Password = model.Password
            };
        }
        public static User ToUser(RegisterModel model)
        {
            return new User
            {
                Username = model.Username,
                Password = model.Password,
                EmailAdress = model.EmailAdress
            };
        }
        
        public static Product ToProduct(AddProductModel model)
        {
            return new Product
            {
                Name = model.Name,
                Prize = model.Prize,
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
