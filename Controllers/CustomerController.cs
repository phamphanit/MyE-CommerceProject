using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinalProject.Common;
using FinalProject.DataModels;
using FinalProject.Helpers;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        private readonly MyDbContext _context;
        public CustomerController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]


        public IActionResult Register(RegisterViewModel model)
        {
            var cust = new Customer
            {
                IdCust = Guid.NewGuid().ToString(),
                NameCust = model.CustName,
                Email = model.Email,
                Phone = model.Phone,
                Role = Common.Role.Customer,
                Status = false,
                RandomKey = MyTools.GetRandom()
            };
            cust.PassWord = model.PassWord.ToSHA512Hash(cust.RandomKey);
            _context.Add(cust);
            _context.SaveChanges();

            return Redirect("/HangHoa");
        }

        public IActionResult SignIn(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SignIn(SignInViewModel model, string ReturnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var cust = _context.Customers.SingleOrDefault(c => c.Email == model.Email);
                if (cust != null && cust.PassWord == model.PassWord.ToSHA512Hash(cust.RandomKey))
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, cust.NameCust),
                        new Claim(ClaimTypes.Email, cust.Email),
                        new Claim(ClaimTypes.Role, cust.Role.ToString()),
                        new Claim(MyClaimType.CustomerID, cust.IdCust)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties { };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return Redirect("/HangHoa");
                };
            }
            return View();

        }
        public IActionResult Profile()
        {
            return View();
        }

    }
}
