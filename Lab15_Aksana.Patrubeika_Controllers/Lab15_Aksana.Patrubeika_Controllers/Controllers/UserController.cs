using Lab15_Aksana.Patrubeika_Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab15_Aksana.Patrubeika_Controllers.Controllers
{
    public class UserController : Controller
    {
        public IActionResult User()
        {
            UserInfo userInfo = new UserInfo();

            userInfo.UserHost = HttpContext.Request.Host.ToString();
            userInfo.UserProtocol = HttpContext.Request.Protocol;
            //return $"Name: {user.UserFirstName}\t{user.UserLastName}\n";
            //return $"Name: Aksana \tPatrubeika\nDate now: {DateTime.Now}\nHost: {userHost}\nProtocol: {userProtocol}\n";
            return View();
        }
    }
}
