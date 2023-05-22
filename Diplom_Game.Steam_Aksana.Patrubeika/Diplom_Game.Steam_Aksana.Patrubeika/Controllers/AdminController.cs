using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Diplom_Game.Steam_Aksana.Patrubeika.Models;
using Diplom_Game.Steam_Aksana.Patrubeika.ViewModel;
using Microsoft.EntityFrameworkCore;
using Diplom_Game.Steam_Aksana.Patrubeika.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Hosting.Internal;
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Drawing.Drawing2D;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Controllers
{
    public class AdminController : Controller
    {
        UserManager<User> _userManager;
        RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public AdminController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        //Users
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var users = (from user in _context.Users
                         join ur in _context.UserRoles on user.Id equals ur.UserId
                         join r in _context.Roles on ur.RoleId equals r.Id
                         where user.Id == ur.UserId
                         select new ViewUsersViewModel
                         {
                             Id = user.Id,
                             SteamName = user.SteamName,
                             Email = user.Email,
                             Country = user.Country,
                             UserLevel = user.UserLevel.LevelName,
                             Role = r.Name
                         }).ToList();

            return View(users);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditUser(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { 
                Id = user.Id, 
                Email = user.Email, 
                SteamName = user.SteamName, 
                Country = user.Country, 
                UserLevelId = user.UserLevelId };
            ViewData["LevelName"] = new SelectList(_context.UserLevels, "UserLevelId", "LevelName");
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.SteamName = model.SteamName;
                    user.Country = model.Country;
                    user.UserLevelId = model.UserLevelId;
                    ViewData["LevelName"] = new SelectList(_context.UserLevels, "UserLevelId", "LevelName", user.UserLevelId);
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditGame(int id)
        {
            Game game = await _context.Games.FirstOrDefaultAsync(x => x.GameId == id);
            if (game == null)
            {
                return NotFound();
            }
            EditGameViewModel model = new EditGameViewModel {
                GameId = game.GameId,
                GameName = game.GameName,
                Img = game.Img,
                DeveloperId = game.DeveloperId,
                ReleaseDate = game.ReleaseDate,
                Reviews = game.Reviews,
                Genre = game.Genre,
                Summary = game.Summary,
                Price = game.Price
            };
            ViewData["DeveloperName"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperName");
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditGame(EditGameViewModel model, IFormFile uploadedFile)
        {
            //что-то тут не так
            if (uploadedFile != null)
            {
                string path = "/img/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_hostingEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                model.Img = path;
            }

            Game game = await _context.Games.FindAsync(model.GameId);
            if (game != null)
            {
                if (uploadedFile != null)
                {
                    game.Img = model.Img;
                }
                game.GameId = model.GameId;
                game.GameName = model.GameName;
                game.DeveloperId = model.DeveloperId;
                game.ReleaseDate = model.ReleaseDate;
                game.Reviews = model.Reviews;
                game.Genre = model.Genre;
                game.Summary = model.Summary;
                game.Price = model.Price;

                ViewData["DeveloperName"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperName", game.DeveloperId);
                _context.Update(game);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Games");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        //Games
        // POST: Games/Create      
        // GET: Games/Create
        [Authorize(Roles = "admin")]
        public IActionResult CreateGame()
        {

            ViewData["DeveloperName"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateGame([Bind("GameId,GameName,DeveloperId,ReleaseDate,Reviews,Genre,Summary,Price")] Game game, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null)
                {
                    string path = "/img/" + uploadedFile.FileName;
                    using (var fileStream = new FileStream(_hostingEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    game.Img = path;
                }
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Games");
            }
            ViewData["DeveloperName"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperName", game.DeveloperId);
            return View(game);
        }

        // GET: Developers/Create
        [Authorize(Roles = "admin")]
        public IActionResult CreateDeveloper()
        {
            return View();
        }

        // POST: Developers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateDeveloper([Bind("DeveloperId,DeveloperName,DeveloperSummary")] Developer developer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(developer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Developer");
            }
            return View(developer);
        }

        // GET: Developers/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteDeveloper(int? id)
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

        // POST: Developers/Delete/5
        [HttpPost, ActionName("DeleteDeveloper")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteDeveloperfirmed(int id)
        {
            if (_context.Developers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Developers'  is null.");
            }
            var developer = await _context.Developers.FindAsync(id);
            if (developer != null)
            {
                _context.Developers.Remove(developer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Developer");
        }
        // GET: Developers/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditDeveloper(int? id)
        {
            if (id == null || _context.Developers == null)
            {
                return NotFound();
            }

            var developer = await _context.Developers.FindAsync(id);
            if (developer == null)
            {
                return NotFound();
            }
            return View(developer);
        }

        // POST: Developers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditDeveloper(int id, [Bind("DeveloperId,DeveloperName,DeveloperSummary")] Developer developer)
        {
            if (id != developer.DeveloperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(developer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeveloperExists(developer.DeveloperId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Developer");
            }
            return View(developer);
        }

        private bool DeveloperExists(int id)
        {
            return (_context.Developers?.Any(e => e.DeveloperId == id)).GetValueOrDefault();
        }
        
    }
}
