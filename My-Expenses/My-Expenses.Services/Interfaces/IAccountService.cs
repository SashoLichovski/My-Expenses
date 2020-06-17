using My_Expenses.Data;
using My_Expenses.Services.Dto;

namespace My_Expenses.Services.Interfaces
{
    public interface IAccountService
    {
        Account GetAccByAccountId(int accountId);
        TransferStatus ValidateTransfer(int amount, Account account);
        void TransferToAccount(int amount, Account account, string toAccount);
        void AddToMainAcc(int amount, Account account);
        AddProductStatus ValidateSpendingAccount(int price, int accountId);
        void SubtractSpendingAccount(int price, int accountId);
        void AddSalesToMainAccount(int dailySales, int accountId);
    }
}
