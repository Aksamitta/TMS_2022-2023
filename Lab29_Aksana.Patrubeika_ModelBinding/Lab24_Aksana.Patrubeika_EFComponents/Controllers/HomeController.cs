using Lab24_Aksana.Patrubeika_EFComponents.Data;
using Lab24_Aksana.Patrubeika_EFComponents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Lab24_Aksana.Patrubeika_EFComponents.Serveces;
using System.IO.Pipelines;
using System.Numerics;

namespace Lab24_Aksana.Patrubeika_EFComponents.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TripsServece _tripServece;
        //private readonly PassengerInfoView _passInfo;

        public HomeController(ILogger<HomeController> logger, TripsServece tripServece)
        {
            _logger = logger;
            _tripServece = tripServece;
        }

               
        
        public IActionResult Trip(string search)
        {
            using (var db = new AirLineContext())
            {
                var tripFirst = db.Trips.Include(c => c.Company).OrderBy(t => t.TripId).ToList();
                
                if (!String.IsNullOrEmpty(search))
                {
                    tripFirst = db.Trips.Where(s => s.Plane.StartsWith(search)).ToList();
                }
                return View(tripFirst.ToList());
            }
        }

        public IActionResult Passenger ()
        {
            using (var db = new AirLineContext())
            {
                var pass = db.Passengers.Include(p => p.PassInTrips).ToList();
                return View(pass.ToList());
            }
        }

        [HttpPost]
        public IActionResult Create(Trip trip)
        {
            _tripServece.AddTrip(trip);
            return RedirectToAction("Trip");
        }

        [HttpGet]
        public IActionResult AddTrip()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePass(Passenger pass)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
                
            _tripServece.AddPassenger(pass);
           
            return View(pass) ;
        }

        [HttpGet]
        public IActionResult AddPassenger()
        {
            return View();
        }

        public IActionResult PassengerInfo()
        {
            List<PassengerInfoView> passInfo = new List<PassengerInfoView>();

            using (var db = new AirLineContext())
            {               
                passInfo = (from trip in db.Trips
                               join passInTrip in db.PassInTrips on trip.TripId equals passInTrip.TripId
                               join pass in db.Passengers on passInTrip.PassengerId equals pass.PassengerId
                               join comp in db.Companies on trip.CompanyId equals comp.CompanyId
                               select new PassengerInfoView
                               {
                                   Id = pass.PassengerId,
                                   Name = pass.Name,
                                   TripId = trip.TripId,
                                   Plane = trip.Plane,
                                   TownFrom = trip.TownFrom,
                                   TownTo = trip.TownTo,
                                   CompanyName = comp.CompanyName
                               }).ToList();
               
                return View(passInfo);
            }
        }

        //sorting
        public IActionResult TripSort(AirLineServeces.TypeOfSort sortOrder = AirLineServeces.TypeOfSort.CompanyAsc)
        {
            using (var db = new AirLineContext())
            {
                IQueryable<Trip>? trips = db.Trips.Include(x => x.Company);

                ViewData["TripSort"] = sortOrder == AirLineServeces.TypeOfSort.TripIdAsc ? AirLineServeces.TypeOfSort.TripIdDesc : AirLineServeces.TypeOfSort.TripIdAsc;
                ViewData["CompanySort"] = sortOrder == AirLineServeces.TypeOfSort.CompanyAsc ? AirLineServeces.TypeOfSort.CompanyDesc : AirLineServeces.TypeOfSort.CompanyAsc;
                ViewData["PlaneSort"] = sortOrder == AirLineServeces.TypeOfSort.PlaneAsc ? AirLineServeces.TypeOfSort.PlaneDesc : AirLineServeces.TypeOfSort.PlaneAsc;
                ViewData["TownFromSort"] = sortOrder == AirLineServeces.TypeOfSort.TownFromAsc ? AirLineServeces.TypeOfSort.TownFromDesc : AirLineServeces.TypeOfSort.TownFromAsc;
                ViewData["TownToSort"] = sortOrder == AirLineServeces.TypeOfSort.TownToAsc ? AirLineServeces.TypeOfSort.TownToDesc : AirLineServeces.TypeOfSort.TownToAsc;

                trips = sortOrder switch
                {
                    AirLineServeces.TypeOfSort.TripIdAsc => trips.OrderBy(t => t.TripId),
                    AirLineServeces.TypeOfSort.TripIdDesc => trips.OrderByDescending(t => t.TripId),
                    AirLineServeces.TypeOfSort.CompanyAsc => trips.OrderBy(t => t.Company!.CompanyName),
                    AirLineServeces.TypeOfSort.CompanyDesc => trips.OrderByDescending(t => t.Company!.CompanyName),
                    AirLineServeces.TypeOfSort.PlaneAsc => trips.OrderBy(t => t.Plane),
                    AirLineServeces.TypeOfSort.PlaneDesc => trips.OrderByDescending(t => t.Plane),
                    AirLineServeces.TypeOfSort.TownFromAsc => trips.OrderBy(t => t.TownFrom),
                    AirLineServeces.TypeOfSort.TownFromDesc => trips.OrderByDescending(t => t.TownFrom),
                    AirLineServeces.TypeOfSort.TownToAsc => trips.OrderBy(t => t.TownTo),
                    AirLineServeces.TypeOfSort.TownToDesc => trips.OrderByDescending(t => t.TownTo)
                };
                return View(trips.ToList());
            }            
        }

        //[HttpPost]
        public IActionResult FindPlane([FromForm] string plane)
        {
            using (var db = new AirLineContext())
            {
                var pl = from b in db.Trips
                         where b.Plane.StartsWith(plane)
                         select b;
                return View (pl.ToList());

            }
            
        }

        public IActionResult GrouppingPlane()
        {
            using (var db = new AirLineContext())
            {
                IQueryable<EnrollmentTripGroup> trips = from trip in db.Trips
                                                        group trip by trip.Company!.CompanyName into compGroup
                                                        select new EnrollmentTripGroup()
                                                        {
                                                            EnrollmentName = compGroup.Key,
                                                            CompanyCount = compGroup.Count(),

                                                        };

                return View(trips.ToList());

            }
            
        }

        public IActionResult Create()
        {
            return View();
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