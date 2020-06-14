using My_Expenses.Data;
using My_Expenses.Repositories.Interfaces;
using My_Expenses.Services.Interfaces;
using System;
using System.Collections.Generic;
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
    }
}
