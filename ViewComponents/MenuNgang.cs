using System.Threading.Tasks;
using FinalProject.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.ViewComponents
{
    public class MenuNgang : ViewComponent
    {
        private readonly MyDbContext DbContext;

        public MenuNgang(MyDbContext context)
        {
            DbContext = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("_MenuLoai", await DbContext.loais.ToListAsync());
        }
    }
}