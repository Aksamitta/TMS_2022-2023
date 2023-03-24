using System.Runtime.Serialization;

namespace Lab24_Aksana.Patrubeika_EFComponents.Models
{
    public class PassengerInfoView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TripId { get; set; }

        public string Plane { get; set; }

        public string TownFrom { get; set; }

        public string TownTo { get; set; }

        public string CompanyName { get; set; }

    }
}
