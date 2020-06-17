using My_Expenses.Data;
using System.Collections.Generic;

namespace My_Expenses.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        List<Product> GetAllByAccountId(int accountId);
        Product GetById(int id);
        void DeleteProduct(Product product);
        void Update(Product product);
        void Populate();
    }
}
