using Lab17_Aksana.Patrubeika_Views.Models;
using Lab17_Aksana.Patrubeika_Views.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab17_Aksana.Patrubeika_Views.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CarService _carService;

        //public List<Car> cars = new List<Car>();

        public HomeController(ILogger<HomeController> logger, CarService carService)
        {
            _logger = logger;
            _carService= carService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
        public IActionResult AddCarsInShop()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            _carService.AddCar(car);
            return RedirectToAction("Index");
        }

       
        public IActionResult ShowCarsInShop()
        {            
            return View(_carService.ShowCars());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}