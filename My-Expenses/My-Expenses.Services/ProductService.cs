using My_Expenses.Data;
using My_Expenses.Repositories.Interfaces;
using My_Expenses.Services.Dto;
using My_Expenses.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My_Expenses.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public CalculatedData CalculateData(List<Product> products)
        {
            var totalAmount = 0;
            products.ForEach(x => totalAmount += x.Prize);

            DateTime startingDate = products.Min(x => x.DateAdded);
            DateTime latestDate = products.Max(x => x.DateAdded);
            return new CalculatedData()
            {
                TotalAmount = totalAmount,
                DateFrom = startingDate.ToString("dddd, MMMM dd, yyyy"),
                DateTo = latestDate.ToString("dddd, MMMM dd, yyyy")
            };
        }

        public void CreateProduct(Product product, int userId)
        {
            var newProduct = new Product()
            {
                Name = product.Name,
                Prize = product.Prize,
                Category = product.Category,
                DateAdded = DateTime.Now,
                UserId = userId
            };
            productRepository.AddProduct(newProduct);
        }

        public void DeleteProduct(Product product)
        {
            productRepository.DeleteProduct(product);
        }

        public List<Product> GetAllByUserId(int userId)
        {
            return productRepository.GetAllByUserId(userId);
        }

        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }

        public void UpdateProduct(Product product, string newName, string newCategory, int newPrize)
        {
            product.Name = newName;
            product.Category = newCategory;
            product.Prize = newPrize;
            productRepository.Update(product);
        }
    }
}
