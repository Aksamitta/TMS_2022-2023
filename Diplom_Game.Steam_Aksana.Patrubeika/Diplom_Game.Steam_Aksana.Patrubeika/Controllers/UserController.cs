using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Diplom_Game.Steam_Aksana.Patrubeika.Data;
using Diplom_Game.Steam_Aksana.Patrubeika.Models;
using Microsoft.AspNetCore.Identity;
using Diplom_Game.Steam_Aksana.Patrubeika.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public UserController(ApplicationDbContext context, UserManager<User> userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [Authorize]
        public async Task<IActionResult> ViewProfile()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userLevel = await _context.Users
                .Include(lev => lev.UserLevel)
                .FirstOrDefaultAsync(x => x.Id == user.Id);
            ProfileViewModel profileViewModel = new ProfileViewModel
            { SteamName = user.SteamName,
                Email = user.Email, 
                Img = user.Img,
                Country = user.Country, 
                UserLevel = userLevel.UserLevel.LevelName};
            
            return View(profileViewModel);
        }

        public async Task<IActionResult> EditProfile()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userLevel = await _context.Users
                .Include(lev => lev.UserLevel)
                .FirstOrDefaultAsync(x => x.Id == user.Id);

            EditUserProfileAccountViewModel userAcc = new EditUserProfileAccountViewModel {
                Id= user.Id,
                SteamName= user.SteamName,
                Age= user.Age,
                Country= user.Country,
                UserLevelId = user.UserLevelId,
                Img = user.Img
            };
            ViewData["LevelName"] = new SelectList(_context.UserLevels, "UserLevelId", "LevelName");
            return View(userAcc);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditUserProfileAccountViewModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = "/user/" + file.FileName;
                    using (var fileStream = new FileStream(_hostingEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    model.Img = path;
                }
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Id= model.Id;
                    user.SteamName= model.SteamName;
                    user.Country = model.Country;
                    user.Img= model.Img;
                    user.Age = model.Age;
                    ViewData["LevelName"] = new SelectList(_context.UserLevels, "UserLevelId", "LevelName", user.UserLevelId);
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ViewProfile");
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


        // GET: User
        public async Task<IActionResult> Index()
        {
              return _context.Users != null ? 
                          View(await _context.Users.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserLevels'  is null.");
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.SteamId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // Переделать Bind
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserLevelId,LevelName")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // need to remake
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserLevelId,LevelName")] UserLevel userLevel)
        {
            if (id != userLevel.UserLevelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLevelExists(userLevel.UserLevelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userLevel);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserLevels == null)
            {
                return NotFound();
            }

            var userLevel = await _context.UserLevels
                .FirstOrDefaultAsync(m => m.UserLevelId == id);
            if (userLevel == null)
            {
                return NotFound();
            }

            return View(userLevel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserLevels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserLevels'  is null.");
            }
            var userLevel = await _context.UserLevels.FindAsync(id);
            if (userLevel != null)
            {
                _context.UserLevels.Remove(userLevel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLevelExists(int id)
        {
          return (_context.UserLevels?.Any(e => e.UserLevelId == id)).GetValueOrDefault();
        }
    }
}
