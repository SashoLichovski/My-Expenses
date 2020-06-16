using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Expenses.Helpers;
using My_Expenses.Services.Interfaces;
using My_Expenses.ViewModels.ProductModels;

namespace My_Expenses.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IAccountService accountService;

        public ProductController(IProductService productService, IAccountService accountService)
        {
            this.productService = productService;
            this.accountService = accountService;
        }
        public IActionResult HomePage()
        {
            ViewBag.header = "All products";
            var userId = int.Parse(User.FindFirst("Id").Value);
            var products = productService.GetAllByUserId(userId);
            var convertedList = products.Select(x => ConvertTo.HomePageModel(x)).ToList();
            var calculationData = productService.CalculateData(products);
            var dataModel = new HomePageCalculatedDataModel()
            {
                Products = convertedList,
                Data = ConvertTo.CalculatedDataModel(calculationData)
            };
            return View(dataModel);
        }
        public IActionResult CustomFilter(string category, DateTime dateFrom, DateTime dateTo, int priceFrom, int priceTo)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            var isValid = productService.ValidateCustomFilter(dateFrom, dateTo, priceFrom, priceTo, userId);
            var dataModel = new HomePageCalculatedDataModel();
            if (isValid.IsValid)
            {
                ViewBag.header = "Custom filter";
                var products = productService.CustomFiltering(category, dateFrom, dateTo, priceFrom, priceTo, userId);
                var convertedList = products.Select(x => ConvertTo.HomePageModel(x)).ToList();
                var calculationData = productService.CalculateData(products);
                dataModel.Products = convertedList;
                dataModel.Data = ConvertTo.CalculatedDataModel(calculationData);
                return View(dataModel);
            }
            dataModel.ErrorMessage = isValid.NotValidMessage;
            return View(dataModel);
        }
        public IActionResult FilterByTimeAndCategory(string time, int dateRange, string category)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);
            var products = productService.FilterByTime(time, dateRange, category, userId);

            var convertedList = products.Select(x => ConvertTo.HomePageModel(x)).ToList();
            var calculationData = productService.CalculateData(products);

            var dataModel = new HomePageCalculatedDataModel()
            {
                Products = convertedList,
                Data = ConvertTo.CalculatedDataModel(calculationData)
            };
            return View(dataModel);
        }
        public IActionResult AddProduct()
        {
            var model = new AddProductModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddProduct(AddProductModel addProductModel)
        {
            if (ModelState.IsValid)
            {
                var userId = int.Parse(User.FindFirst("Id").Value);
                var status = accountService.ValidateSpendingAccount(addProductModel.Price, userId);
                if (status.IsValid)
                {
                    accountService.SubtractSpendingAccount(addProductModel.Price, userId);
                    var product = ReverseModel.ToProduct(addProductModel);
                    productService.CreateProduct(product, userId);
                    var statusModel = ConvertTo.AddProductResultModel(status, addProductModel.Price, addProductModel.Name);
                    return RedirectToAction("AddProductResult", statusModel);
                }
                else
                {
                    var statusModel = ConvertTo.AddProductResultModel(status, addProductModel.Price, addProductModel.Name);
                    return RedirectToAction("AddProductResult", statusModel);
                }
            }
            return View(addProductModel);
        }
        public IActionResult AddProductResult(AddProductResultModel model)
        {
            return View(model);
        }
        public IActionResult EditProduct(int id)
        {
            var product = productService.GetById(id);
            var converted = ConvertTo.EditProductModel(product);
            return View(converted);
        }
        [HttpPost]
        public IActionResult EditProduct(EditProductModel model)
        {
            if (ModelState.IsValid)
            {
                var product = productService.GetById(model.Id);
                productService.UpdateProduct(product, model.Name, model.Category, model.Price);
                return RedirectToAction("HomePage");
            }
            return View(model);
        }
        public IActionResult RemoveProduct(int id)
        {
            var product = productService.GetById(id);
            productService.DeleteProduct(product);
            return RedirectToAction("HomePage");
        }
        public IActionResult EditNote(int id)
        {
            var product = productService.GetById(id);
            var model = ConvertTo.EditNoteModel(product);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditNote(EditNoteModel model)
        {
            var product = ReverseModel.ToProduct(model);
            productService.UpdateNote(product);
            return RedirectToAction("HomePage");
        }
    }
}
