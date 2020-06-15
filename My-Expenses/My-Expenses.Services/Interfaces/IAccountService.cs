using My_Expenses.Data;
using My_Expenses.Services.Dto;

namespace My_Expenses.Services.Interfaces
{
    public interface IAccountService
    {
        Account GetAccByUserId(int userId);
        TransactionStatus ValidateTransfer(int amount, Account account);
        void TransferToSavings(int amount, Account account);
    }
}
