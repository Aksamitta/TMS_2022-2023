using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Diplom_Game.Steam_Aksana.Patrubeika.Data;
using Diplom_Game.Steam_Aksana.Patrubeika.Models;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeveloperController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Developers
        public async Task<IActionResult> Index()
        {
            return _context.Developers != null ?
                        View(await _context.Developers.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Developers'  is null.");
        }

        // GET: Developers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Developers == null)
            {
                return NotFound();
            }

            var developer = await _context.Developers
                .FirstOrDefaultAsync(m => m.DeveloperId == id);
            if (developer == null)
            {
                return NotFound();
            }

            return View(developer);
        }

        
    }

        
}
