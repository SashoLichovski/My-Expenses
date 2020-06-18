using My_Expenses.Data;
using My_Expenses.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_Expenses.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly MyExpensesContext context;

        public SalesRepository(MyExpensesContext context)
        {
            this.context = context;
        }

        public void Populate()
        {
            var notes = new List<string> { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce blandit tristique egestas. Integer ut turpis lectus. Morbi cursus sit amet felis in lobortis.",
            "Donec sagittis sem at dolor gravida pulvinar. Sed consequat dui nec lobortis varius. Nunc viverra interdum placerat. Maecenas ut iaculis lacus. Phasellus metus odio, venenatis et faucibus sed, placerat a elit.",
            "Duis ac nisi at lorem laoreet volutpat vel eget dui. Pellentesque blandit libero eu ex bibendum, ut volutpat erat volutpat. Integer est tortor, volutpat id sagittis sed, accumsan vitae purus. Proin malesuada quam eu quam euismod, a mattis metus sollicitudin. Phasellus ut est ac ligula rutrum posuere. Sed volutpat risus justo, a tristique nisi pretium vitae. Curabitur risus ex, ornare non urna vel, tincidunt tempor velit.",
            "Donec a dictum enim, nec eleifend mi. Praesent dolor odio, faucibus et arcu sit amet, tempor suscipit nunc.",
            "Nam facilisis vitae sapien mollis tincidunt. Suspendisse potenti. Aenean efficitur augue a augue iaculis, quis venenatis erat facilisis. Suspendisse eget orci vel sapien vestibulum lacinia sit amet sit amet sapien. Morbi molestie nibh dui, sit amet rhoncus nisl placerat vel. Nam sed ligula turpis. Ut dignissim porttitor mi, non gravida nunc porttitor in."};
            var r = new Random();
            for (int i = 0; i < 488; i++)
            {
                var sale = new Sale()
                {
                    AccountId = 1,
                    DateCreated = DateTime.Now.AddDays(-i),
                    EmployeeUsername = "andrej",
                    DailySalesAmount = r.Next(5300, 12000)
                };
                if (i % 3 == 0)
                {
                    sale.Note = notes[r.Next(5)];
                }
                context.Sales.Add(sale);
                context.SaveChanges();
            }
            for (int i = 0; i < 488; i++)
            {
                var sale = new Sale()
                {
                    AccountId = 1,
                    DateCreated = DateTime.Now.AddDays(-i),
                    EmployeeUsername = "ivana",
                    DailySalesAmount = r.Next(5300, 12000)
                };
                if (i % 3 == 0)
                {
                    sale.Note = notes[r.Next(5)];
                }
                context.Sales.Add(sale);
                context.SaveChanges();
            }
            for (int i = 0; i < 488; i++)
            {
                var sale = new Sale()
                {
                    AccountId = 1,
                    DateCreated = DateTime.Now.AddDays(-i),
                    EmployeeUsername = "hristijan",
                    DailySalesAmount = r.Next(5300, 12000)
                };
                if (i % 3 == 0)
                {
                    sale.Note = notes[r.Next(5)];
                }
                context.Sales.Add(sale);
                context.SaveChanges();
            }
        }
        public void Add(Sale dbSale)
        {
            context.Sales.Add(dbSale);
            context.SaveChanges();
        }

        public List<Sale> GetAll(int accountId)
        {
            return context.Sales
                .Where(x => x.AccountId == accountId)
                .OrderByDescending(x => x.DateCreated)
                .ToList();
        }

        public List<Sale> GetAllForUser(int accountId, string employeeUsername)
        {
            return context.Sales
                .Where(x => x.AccountId == accountId && x.EmployeeUsername == employeeUsername)
                .ToList();
        }
    }
}
