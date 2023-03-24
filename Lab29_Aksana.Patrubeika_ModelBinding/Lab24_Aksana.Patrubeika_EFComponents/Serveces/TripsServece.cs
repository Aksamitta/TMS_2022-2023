using Lab24_Aksana.Patrubeika_EFComponents.Data;
using Lab24_Aksana.Patrubeika_EFComponents.Models;

namespace Lab24_Aksana.Patrubeika_EFComponents.Serveces
{
    public class TripsServece
    {
        List<Trip> trips = new List<Trip>();
        AirLineContext db = new AirLineContext();
        List<Passenger> passenger= new List<Passenger>();

        public Trip AddTrip(Trip trip)
        {
            db.Add(trip);
            db.SaveChanges();
            return (trip);
        }

        public Passenger AddPassenger(Passenger pass)
        {
            db.Add(pass);
            db.SaveChanges();
            return (pass);
        }


    }
} 
