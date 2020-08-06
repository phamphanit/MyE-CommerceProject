using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class CartController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}