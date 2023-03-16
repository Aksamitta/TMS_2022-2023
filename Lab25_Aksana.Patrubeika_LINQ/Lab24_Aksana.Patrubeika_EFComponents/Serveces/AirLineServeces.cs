using System.ComponentModel.DataAnnotations;

namespace Lab24_Aksana.Patrubeika_EFComponents.Serveces

{
    public class AirLineServeces
    {
        public enum TypeOfSort
        {
            TripIdAsc,
            TripIdDesc,
            CompanyAsc,
            CompanyDesc,
            PlaneAsc,
            PlaneDesc,
            TownFromAsc,
            TownFromDesc,
            TownToAsc,
            TownToDesc,


            //[Display(Name = "TripId")]
            //TripId,
            //[Display(Name = "Company")]
            //Company,
            //[Display(Name = "Plane")]
            //Plane,
            //[Display(Name = "TownFrom")]
            //TownFrom,
            //[Display(Name = "TownTo")]
            //TownTo
        }
    }
}
