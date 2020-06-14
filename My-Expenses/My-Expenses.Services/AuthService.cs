using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using My_Expenses.Data;
using My_Expenses.Repositories.Interfaces;
using My_Expenses.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace My_Expenses.Services
{
    public class AuthService : IAuthService
    {
        public IUserRepository UserRepository { get; }
        public AuthService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task<bool> SignInAsync(User user, HttpContext httpContext)
        {
            var getUser = UserRepository.GetByUsername(user.Username);
            if (getUser != null && user.Password == getUser.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, getUser.Username),
                    new Claim(ClaimTypes.Name, getUser.Username),
                    new Claim("Id", getUser.Id.ToString()),
                    new Claim("IsLoggedIn", "True")
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await httpContext.SignInAsync(principal);

                return true;
            }
            return false;
        }
        public bool Validate(string username)
        {
            var user = UserRepository.GetByUsername(username);
            if (user == null)
            {
                return true;
            }
            return false;
        }
        public void RegisterUser(User user)
        {
            UserRepository.Add(user);
        }

        public void SignOut(HttpContext httpContext)
        {
            httpContext.SignOutAsync();
        }
    }
}
