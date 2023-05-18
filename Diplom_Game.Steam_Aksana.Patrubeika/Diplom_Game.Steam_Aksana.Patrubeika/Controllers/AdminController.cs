using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Diplom_Game.Steam_Aksana.Patrubeika.Models;
using Diplom_Game.Steam_Aksana.Patrubeika.ViewModel;
using Microsoft.EntityFrameworkCore;
using Diplom_Game.Steam_Aksana.Patrubeika.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Controllers
{
    public class AdminController : Controller
    {
        UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        //Users
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Users.Include(g => g.UserLevel);
            return View(await applicationDbContext.ToListAsync());
        }

        //public IActionResult CreateUser() => View();

        //[HttpPost]
        //public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = new User { SteamName = model.SteamName, Email = model.Email, UserName = model.Email, Country = model.Country };
        //        var result = await _userManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //    }
        //    return View(model);
        //}

        public async Task<IActionResult> EditUser(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email, SteamName = user.SteamName, Country = user.Country, UserLevelId = user.UserLevelId };
            ViewData["LevelName"] = new SelectList(_context.UserLevels, "UserLevelId", "LevelName");
            return View(model);
        }

        [HttpPost]
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

        [HttpPost]
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
        public IActionResult CreateGame()
        {
            ViewData["DeveloperName"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGame([Bind("GameId,GameName,DeveloperId,ReleaseDate,Reviews,Genre,Summary,Price")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction("Games", "Index");
            }
            ViewData["DeveloperName"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperName", game.DeveloperId);            
            return View(game);
            
        }



        //// GET: Games/Create
        //public IActionResult CreateDeveloper()
        //{
        //    ViewData["DeveloperId"] = new SelectList(_context.Developers, "DeveloperId", "DeveloperName");
        //    return View("Games", "Index");
        //}

       
    }
}
