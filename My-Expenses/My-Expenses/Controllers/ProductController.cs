using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using My_Expenses.Helpers;
using My_Expenses.Services.Interfaces;
using My_Expenses.ViewModels.ProductModels;

namespace My_Expenses.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult HomePage()
        {
            var userId = int.Parse(User.FindFirst("Id").Value);
            var products = productService.GetAllByUserId(userId);
            var convertedList = products.Select(x => ConvertTo.ToHomePageModel(x)).ToList();
            return View(convertedList);
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
        public IActionResult RemoveProduct(int id)
        {
            var product = productService.GetById(id);
            productService.DeleteProduct(product);
            return RedirectToAction("HomePage");
        }
    }
}
