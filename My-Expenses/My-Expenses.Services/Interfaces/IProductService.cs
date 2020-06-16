using My_Expenses.Data;
using My_Expenses.Services.Dto;
using System;
using System.Collections.Generic;

namespace My_Expenses.Services.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(Product product, int userId);
        List<Product> GetAllByUserId(int userId);
        Product GetById(int id);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product, string newName, string newCategory, int newPrice);
        CalculatedData CalculateData(List<Product> products);
        List<Product> CustomFiltering(string category, DateTime dateFrom, DateTime dateTo, int priceFrom, int priceTo, int userId);
        CustomFilterValidation ValidateCustomFilter(DateTime dateFrom, DateTime dateTo, int priceFrom, int priceTo, int userId);
        List<Product> FilterByTime(string time, int dateRange, string category, int userId);
        void UpdateNote(Product product);
    }
}
