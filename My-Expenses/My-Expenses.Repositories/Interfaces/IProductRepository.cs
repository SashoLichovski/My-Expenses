using My_Expenses.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace My_Expenses.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        List<Product> GetAllByUserId(int userId);
        Product GetById(int id);
        void DeleteProduct(Product product);
        void Update(Product product);
    }
}
