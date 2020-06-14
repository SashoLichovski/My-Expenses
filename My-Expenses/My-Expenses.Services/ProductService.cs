﻿using My_Expenses.Data;
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

        public List<Product> CustomFiltering(string category, DateTime dateFrom, DateTime dateTo, int prizeFrom, int prizeTo, int userId)
        {
            var filteredByCategory = new List<Product>();
            var allProducts = productRepository.GetAllByUserId(userId);
            if (category == "all")
            {
                filteredByCategory = allProducts
                    .Where(x => x.DateAdded >= dateFrom && x.DateAdded <= dateTo &&
                        x.Prize >= prizeFrom && x.Prize <= prizeTo)
                    .OrderByDescending(x => x.DateAdded)
                    .ToList();
            }
            else
            {
                filteredByCategory = allProducts
                    .Where(x => x.Category == category &&
                        x.DateAdded >= dateFrom && x.DateAdded <= dateTo &&
                        x.Prize >= prizeFrom && x.Prize <= prizeTo)
                    .OrderByDescending(x => x.DateAdded)
                    .ToList();
            }

            return filteredByCategory;
        }
        public CustomFilterValidation ValidateCustomFilter(DateTime dateFrom, DateTime dateTo, int prizeFrom, int prizeTo, int userId)
        {
            var validation = new CustomFilterValidation();
            var allProducts = productRepository.GetAllByUserId(userId);
            var prizeRange = allProducts.Where(x => x.Prize >= prizeFrom && x.Prize <= prizeTo).ToList();
            var dateRange = allProducts.Where(x => x.DateAdded >= dateFrom && x.DateAdded <= dateTo).ToList();
            if (prizeRange.Count == 0)
            {
                validation.IsValid = false;
                validation.NotValidMessage = "No products found in the prize range you entered";
            }
            if (dateRange.Count == 0)
            {
                validation.IsValid = false;
                validation.NotValidMessage = "No products found in the date range you entered";
            }
            if (prizeRange.Count == 0 && dateRange.Count == 0)
            {
                validation.IsValid = false;
                validation.NotValidMessage = "No products found in both prize and date range";
            }
            if(prizeRange.Count > 0 && dateRange.Count > 0)
            {
                validation.IsValid = true;
            }
            return validation;
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

        public List<Product> FilterByMonth(int noOfMonths, int userId)
        {
            var allProducts = productRepository.GetAllByUserId(userId);
            allProducts = allProducts.Where(x => x.DateAdded > DateTime.Now.AddMonths(-noOfMonths)).ToList();
            return allProducts;
        }

    }
}
