using Lab26_EFCore_Practice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Diagnostics;
using System.IO.Pipelines;

namespace Lab26_EFCore_Practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Auto()
        {
            List<Auto> autos = new List<Auto>();
            using (var context = new Lab26AutoContext())
            {
                var autoFirst = context.Autos.Include(p => p.Magazines).ToList();
                return View(autoFirst.ToList());
            }               
        }

        public IActionResult Client()
        {
            List<Client> clients = new List<Client>();
            using (var context = new Lab26AutoContext())
            {
                var clientFirst = context.Clients.Include(p => p.Magazines).ToList();
                return View(clientFirst.ToList());
            }
        }

        [HttpPost]
        public IActionResult Create ([FromForm]string model, [FromForm] int year, [FromForm] decimal price)
        {
            using (var context = new Lab26AutoContext())
            {
                var auto = new Auto { AutoModel = model, Year = year, Price = price };
                context.Add(auto);
                context.SaveChanges();                
            }
            return RedirectToAction("Auto");
        }

        [HttpGet]
        public IActionResult AddAuto()
        {
            return View();
        }

        public IActionResult DeleteCar(int id)
        {
            using (var context = new Lab26AutoContext())
            {
                var auto = new Auto { AutoId = id };
                context.Remove(auto);
                context.SaveChanges();
            }
                return RedirectToAction("Index");
        }

        public IActionResult InfoCars(int id)
        {
            using (var context = new Lab26AutoContext())
            {                
                var autoShow = (from auto in context.Autos.Include(p => p.Magazines)
                                join magazine in context.Magazines on auto.AutoId equals magazine.AutoId
                                join employee in context.Employees on magazine.EmployeeId equals employee.EmployeeId
                                join client in context.Clients on magazine.ClientId equals client.ClientId

                                where auto.AutoId.Equals(id)
                                select new
                                {
                                    Id = auto.AutoId,
                                    Model = auto.AutoModel,
                                    Price = auto.Price,
                                    Seller = employee.EmployeeName,
                                    Buyer = client.ClientName + ' ' + client.ClientSname,
                                    Date = magazine.Date
                                }).ToList();
                return View(autoShow.ToList());
            }
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
    }
}