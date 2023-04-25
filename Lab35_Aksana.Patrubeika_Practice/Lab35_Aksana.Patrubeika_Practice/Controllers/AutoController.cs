using Lab35_Aksana.Patrubeika_Practice.Data;
using Lab35_Aksana.Patrubeika_Practice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace Lab35_Aksana.Patrubeika_Practice.Controllers
{
    public class AutoController : Controller
    {
        private readonly ILogger<AutoController> _logger;

        public AutoController(ILogger<AutoController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Auto()
        {
            List<Auto> autos = new List<Auto>();
            using (var context = new ApplicationDbContext())
            {
                var autoFirst = context.Autos.Include(p => p.Magazines).ToList();
                return View(autoFirst.ToList());
            }
        }

        [Authorize(Roles = "admin")]
        public IActionResult Client()
        {
            List<Client> clients = new List<Client>();
            using (var context = new ApplicationDbContext())
            {
                var clientFirst = context.Clients.Include(p => p.Magazines).ToList();
                return View(clientFirst.ToList());
            }
        }
        
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Create([FromForm] string model, [FromForm] int year, [FromForm] decimal price)
        {
            using (var context = new ApplicationDbContext())
            {
                var auto = new Auto { AutoModel = model, Year = year, Price = price };
                context.Add(auto);
                context.SaveChanges();
            }
            return RedirectToAction("Auto");
        }
        
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AddAuto()
        {
            return View();
        }


        [Authorize(Roles = "admin")]
        public IActionResult DeleteCar(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var auto = new Auto { AutoId = id };
                context.Remove(auto);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult InfoCars(int id)
        {

            List<AutoInfo> autoInfo = new List<AutoInfo>();

            using (var context = new ApplicationDbContext())
            {
                autoInfo = (from auto in context.Autos
                            join magazine in context.Magazines on auto.AutoId equals magazine.AutoId
                            join employee in context.Employees on magazine.EmployeeId equals employee.EmployeeId
                            join client in context.Clients on magazine.ClientId equals client.ClientId

                            where auto.AutoId == id
                            select new AutoInfo
                            {
                                Id = auto.AutoId,
                                Model = auto.AutoModel,
                                Year = auto.Year,
                                Price = auto.Price,
                                Seller = employee.EmployeeName,
                                Buyer = client.ClientName + ' ' + client.ClientSname,
                                Date = magazine.Date
                            }).ToList();

            }
            return View(autoInfo);
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

    }
}
