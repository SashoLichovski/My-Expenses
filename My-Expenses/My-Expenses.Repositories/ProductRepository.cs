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

        public List<Product> GetAllByAccountId(int accountId)
        {
            return context.Products
                .Where(x => x.AccountId == accountId)
                .OrderByDescending(x => x.DateAdded)
                .ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Populate()
        {
            var r = new Random();
            var employees = new List<string> { "andrej", "hristijan", "ivana", "developer" };
            var notes = new List<string> { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce blandit tristique egestas. Integer ut turpis lectus. Morbi cursus sit amet felis in lobortis.",
            "Donec sagittis sem at dolor gravida pulvinar. Sed consequat dui nec lobortis varius. Nunc viverra interdum placerat. Maecenas ut iaculis lacus. Phasellus metus odio, venenatis et faucibus sed, placerat a elit.",
            "Duis ac nisi at lorem laoreet volutpat vel eget dui. Pellentesque blandit libero eu ex bibendum, ut volutpat erat volutpat. Integer est tortor, volutpat id sagittis sed, accumsan vitae purus. Proin malesuada quam eu quam euismod, a mattis metus sollicitudin. Phasellus ut est ac ligula rutrum posuere. Sed volutpat risus justo, a tristique nisi pretium vitae. Curabitur risus ex, ornare non urna vel, tincidunt tempor velit.",
            "Donec a dictum enim, nec eleifend mi. Praesent dolor odio, faucibus et arcu sit amet, tempor suscipit nunc.",
            "Nam facilisis vitae sapien mollis tincidunt. Suspendisse potenti. Aenean efficitur augue a augue iaculis, quis venenatis erat facilisis. Suspendisse eget orci vel sapien vestibulum lacinia sit amet sit amet sapien. Morbi molestie nibh dui, sit amet rhoncus nisl placerat vel. Nam sed ligula turpis. Ut dignissim porttitor mi, non gravida nunc porttitor in."};
            var names = new List<string> { "Bread", "Sugar", "Coffee", "Chairs", "Table", "Computer", "Coffee machine", "Pizza", "Computer", "Meat" };
            var categories = new List<string> { "Food and drinks", "Interior", "Bills", "Other" };
            for (int i = 0; i < 500; i++)
            {
                var product = new Product()
                {
                    AccountId = 1,
                    Name = names[r.Next(10)],
                    BoughtBy = employees[r.Next(4)],
                    DateAdded = DateTime.Now.AddDays(-i),
                    Category = categories[r.Next(4)],
                    Price = r.Next(200, 4000),
                };
                if (i % 5 == 0)
                {
                    product.Note = notes[r.Next(5)];
                }
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }
    }
}
