using My_Expenses.Data;
using My_Expenses.Repositories.Interfaces;
using My_Expenses.Services.Dto;
using My_Expenses.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
            products.ForEach(x => totalAmount += x.Price);
            if (products.Count > 0)
            {
                DateTime startingDate = products.Min(x => x.DateAdded);
                DateTime latestDate = products.Max(x => x.DateAdded);
                return new CalculatedData()
                {
                    TotalAmount = totalAmount,
                    DateFrom = startingDate.ToString("dddd, MMMM dd, yyyy"),
                    DateTo = latestDate.ToString("dddd, MMMM dd, yyyy")
                };
            }
            return new CalculatedData();
        }

        public void CreateProduct(Product product, int accountId, int userId, string username)
        {
            var newProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = DateTime.Now,
                AccountId = accountId,
                Note = product.Note,
                BoughtBy = username
            };
            productRepository.AddProduct(newProduct);
        }

        public List<Product> CustomFiltering(string category, DateTime dateFrom, DateTime dateTo, int priceFrom, int priceTo, int accountId)
        {
            var filteredByCategory = new List<Product>();
            var allProducts = productRepository.GetAllByAccountId(accountId);
            if (category == "all")
            {
                filteredByCategory = allProducts
                    .Where(x => x.DateAdded >= dateFrom && x.DateAdded <= dateTo &&
                        x.Price >= priceFrom && x.Price <= priceTo)
                    .OrderByDescending(x => x.DateAdded)
                    .ToList();
            }
            else
            {
                filteredByCategory = allProducts
                    .Where(x => x.Category == category &&
                        x.DateAdded >= dateFrom && x.DateAdded <= dateTo &&
                        x.Price >= priceFrom && x.Price <= priceTo)
                    .OrderByDescending(x => x.DateAdded)
                    .ToList();
            }

            return filteredByCategory;
        }
        public CustomFilterValidation ValidateCustomFilter(DateTime dateFrom, DateTime dateTo, int priceFrom, int priceTo, int accountId, string category)
        {
            var validation = new CustomFilterValidation();
            var allProducts = productRepository.GetAllByAccountId(accountId);
            var priceRange = allProducts.Where(x => x.Price >= priceFrom && x.Price <= priceTo).ToList();
            var dateRange = allProducts.Where(x => x.DateAdded >= dateFrom && x.DateAdded <= dateTo).ToList();
            var categoryRange = new List<Product>();
            if (category != "all")
            {
                categoryRange = allProducts.Where(x => x.Category == category &&
                            x.DateAdded >= dateFrom && x.DateAdded <= dateTo &&
                            x.Price >= priceFrom && x.Price <= priceTo)
                        .OrderByDescending(x => x.DateAdded)
                        .ToList();
            }
            else
            {
                categoryRange = allProducts;
            }
            if (priceRange.Count == 0)
            {
                validation.IsValid = false;
                validation.NotValidMessage = "No products found in the price range you entered";
            }
            if (dateRange.Count == 0)
            {
                validation.IsValid = false;
                validation.NotValidMessage = "No products found in the date range you entered";
            }
            if (categoryRange.Count == 0)
            {
                validation.IsValid = false;
                validation.NotValidMessage = "No products found in this category for the given price range or date range";
            }
            if (priceRange.Count == 0 && dateRange.Count == 0 && categoryRange.Count == 0)
            {
                validation.IsValid = false;
                validation.NotValidMessage = "No products found in all fields ( date range, price range, category )";
            }
            if (priceRange.Count == 0 && dateRange.Count == 0 && categoryRange.Count > 0)
            {
                validation.IsValid = false;
                validation.NotValidMessage = "No products found in requested price range and date range";
            }
            if (priceRange.Count > 0 && dateRange.Count > 0 && categoryRange.Count > 0)
            {
                validation.IsValid = true;
            }
            return validation;
        }
        public void DeleteProduct(Product product)
        {
            productRepository.DeleteProduct(product);
        }

        public List<Product> GetAllByAccountId(int accountId)
        {
            return productRepository.GetAllByAccountId(accountId);
        }

        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }

        public void UpdateProduct(Product product, string newName, string newCategory, int newPrice)
        {
            product.Name = newName;
            product.Category = newCategory;
            product.Price = newPrice;
            productRepository.Update(product);
        }
        public List<Product> FilterByTime(string time, int dateRange, string category, int accountId)
        {
            if (time == "month")
            {
                var allProducts = productRepository.GetAllByAccountId(accountId)
                .Where(x => x.DateAdded > DateTime.Now.AddMonths(-dateRange))
                .ToList();
                var filteredList = allProducts;
                if (category != "all")
                {
                    filteredList = allProducts
                    .Where(x => x.Category == category)
                    .ToList();
                }
                return filteredList;
            }
            else if (time == "week")
            {
                dateRange *= 7;
                var allProducts = productRepository.GetAllByAccountId(accountId)
                    .Where(x => x.DateAdded > DateTime.Now.AddDays(-dateRange))
                    .ToList();
                var filteredList = allProducts;
                if (category != "all")
                {
                    filteredList = allProducts
                    .Where(x => x.Category == category)
                    .ToList();
                }
                return filteredList;
            }
            else 
            {
                var allProducts = productRepository.GetAllByAccountId(accountId)
                .Where(x => x.DateAdded > DateTime.Now.AddDays(-dateRange))
                .ToList();
                var filteredList = allProducts;
                if (category != "all")
                {
                    filteredList = allProducts
                    .Where(x => x.Category == category)
                    .ToList();
                }
                return filteredList;
            }
        }

        public void UpdateNote(Product product)
        {
            var dbProduct = productRepository.GetById(product.Id);
            dbProduct.Note = product.Note;
            productRepository.Update(dbProduct);
        }
    }
}
