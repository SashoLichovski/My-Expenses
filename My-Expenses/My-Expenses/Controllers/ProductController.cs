using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Expenses.Helpers;
using My_Expenses.Services.Interfaces;
using My_Expenses.ViewModels.ProductModels;

namespace My_Expenses.Controllers
{
    //[Authorize(Policy = "IsLoggedIn")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
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
        public IActionResult ByMonth(string time ,int noOfMonths, string category)
        {
            _ = noOfMonths == 1 ? ViewBag.header = "Last month" : ViewBag.header = $"Last {noOfMonths} months";

            var userId = int.Parse(User.FindFirst("Id").Value);
            var products = productService.FilterByTime(time, noOfMonths, category, userId);

            var convertedList = products.Select(x => ConvertTo.HomePageModel(x)).ToList();
            var calculationData = productService.CalculateData(products);

            var dataModel = new HomePageCalculatedDataModel()
            {
                Products = convertedList,
                Data = ConvertTo.CalculatedDataModel(calculationData)
            };
            return View(dataModel);
        }
        public IActionResult ByWeek(string time, int noOfWeeks, string category)
        {
            _ = noOfWeeks == 1 ? ViewBag.header = "Last week" : ViewBag.header = $"Last {noOfWeeks} weeks";

            var userId = int.Parse(User.FindFirst("Id").Value);
            var products = productService.FilterByTime(time, noOfWeeks, category, userId);

            var convertedList = products.Select(x => ConvertTo.HomePageModel(x)).ToList();
            var calculationData = productService.CalculateData(products);

            var dataModel = new HomePageCalculatedDataModel()
            {
                Products = convertedList,
                Data = ConvertTo.CalculatedDataModel(calculationData)
            };
            return View(dataModel);
        }
        public IActionResult ByDay(string time, int noOfDays, string category)
        {
            _ = noOfDays == 1 ? ViewBag.header = "Last day" : ViewBag.header = $"Last {noOfDays} days";

            var userId = int.Parse(User.FindFirst("Id").Value);
            var products = productService.FilterByTime(time, noOfDays, category, userId);

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
                var product = ReverseModel.ToProduct(addProductModel);
                var userId = int.Parse(User.FindFirst("Id").Value);
                productService.CreateProduct(product, userId);
                return RedirectToAction("HomePage");
            }
            return View(addProductModel);
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
                productService.UpdateProduct(product, model.Name, model.Category, model.Prize);
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
