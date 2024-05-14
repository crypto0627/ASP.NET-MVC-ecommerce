using Microsoft.AspNetCore.Mvc;
using Menu.Data;
using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class Menu : Controller
    {
        private readonly MenuContext _context;
        public Menu(MenuContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View( await _context.Dishes.ToListAsync() );
        }
    }
}
