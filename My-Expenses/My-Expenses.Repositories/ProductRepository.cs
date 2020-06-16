using Microsoft.EntityFrameworkCore;
using My_Expenses.Data;
using My_Expenses.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My_Expenses.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyExpensesContext context;

        public ProductRepository(MyExpensesContext context)
        {
            this.context = context;
        }
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<Product> GetAllByUserId(int userId)
        {
            return context.Products
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.DateAdded)
                .ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

    }
}
