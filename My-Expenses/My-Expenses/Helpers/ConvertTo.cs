using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using My_Expenses.Data;
using My_Expenses.Services.Dto;
using My_Expenses.ViewModels.AccountModels;
using My_Expenses.ViewModels.ProductModels;
using My_Expenses.ViewModels.SalesModels;

namespace My_Expenses.Helpers
{
    public static class ConvertTo
    {
        internal static HomePageModel HomePageModel(Product product)
        {
            var newModel = new HomePageModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                DateCreated = product.DateAdded.ToString("dddd, MMMM dd, yyyy"),
                Category = product.Category,
                BoughtBy = product.BoughtBy
            };
            if (!string.IsNullOrEmpty(product.Note))
            {
                newModel.Note = product.Note;
            }
            return newModel;
        }

        internal static AccountOverviewModel AccountOverviewModel(Account account)
        {
            return new AccountOverviewModel
            {
                Id = account.Id,
                MainAccount = account.MainAccount,
                SavingsAccount = account.SavingsAccount,
                SpendingAccount = account.SpendingAccount
            };
        }

        internal static TransferResultModel TransferResultModel(TransferStatus status, int amount, int leftOnAcc)
        {
            return new TransferResultModel
            {
                IsValid = status.IsValid,
                ResultMessage = status.ResultMessage,
                AmountTransfered = amount,
                AmountLeft = leftOnAcc
            };
        }

        internal static SalesOverviewModel SalesOverviewModel(Sale salesList)
        {
            return new SalesOverviewModel
            {
                DailySalesAmount = salesList.DailySalesAmount,
                EmployeeUsername = salesList.EmployeeUsername,
                Note = salesList.Note,
                DateCreated = salesList.DateCreated.ToString("dddd, MMMM dd, yyyy")
            };
        }

        internal static AddProductResultModel AddProductResultModel(AddProductStatus status, int amount, string productName)
        {
            return new AddProductResultModel
            {
                IsValid = status.IsValid,
                ResultMessage = status.ResultMessage,
                AmountLeft = status.AccountRemainingBalance,
                ProductPrice = amount,
                ProductName = productName
            };
        }

        internal static EditProductModel EditProductModel(Product product)
        {
            return new EditProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category
            };
        }
        internal static CalculatedDataModel CalculatedDataModel(CalculatedData model)
        {
            return new CalculatedDataModel
            {
                TotalAmount = model.TotalAmount,
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            };
        }

        internal static EditNoteModel EditNoteModel(Product product)
        {
            return new EditNoteModel
            {
                Note = product.Note
            };
        }
    }
}
