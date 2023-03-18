using Lab26_EFCore_Practice.Models;
using Lab26_EFCore_Practice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Diagnostics;
using System.IO.Pipelines;

namespace Lab26_EFCore_Practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly AutoInfo _infoService;
        private readonly AutoService _autoService;

        public HomeController(ILogger<HomeController> logger, AutoService autoService)
        {
            _logger = logger;
            //_infoService = infoService;
            _autoService = autoService;
        }

        //show autos list
        public IActionResult Auto()
        {            
            return View(_autoService.ShowAutosInShop());
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

        //разобраться в смысле двух этих методов, почему у них разные имена
        [HttpPost]
        public IActionResult Create (Auto auto)
        {
            _autoService.AddAuto(auto);

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

            List<AutoInfo> autoInfo = new List<AutoInfo>();

            using (var context = new Lab26AutoContext())
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