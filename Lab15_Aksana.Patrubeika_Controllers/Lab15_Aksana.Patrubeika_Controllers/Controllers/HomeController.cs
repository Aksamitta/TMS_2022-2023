using Lab15_Aksana.Patrubeika_Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab15_Aksana.Patrubeika_Controllers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult User()
        {
            UserInfo userInfo = new UserInfo();

            userInfo.UserHost = HttpContext.Request.Host.ToString();
            userInfo.UserProtocol = HttpContext.Request.Protocol;
            //return $"Name: {user.UserFirstName}\t{user.UserLastName}\n";
            //return $"Name: Aksana \tPatrubeika\nDate now: {DateTime.Now}\nHost: {userHost}\nProtocol: {userProtocol}\n";
            return View(userInfo);
            
        }
    }
}