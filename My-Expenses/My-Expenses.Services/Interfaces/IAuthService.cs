using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using My_Expenses.Data;

namespace My_Expenses.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(User user, HttpContext httpContext);
        bool Validate(string username);
        void RegisterUser(User user);
        void SignOut(HttpContext httpContext);
        void RegisterEmployee(User user, int accountId);
    }
}
