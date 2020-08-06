using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class HangHoaController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}