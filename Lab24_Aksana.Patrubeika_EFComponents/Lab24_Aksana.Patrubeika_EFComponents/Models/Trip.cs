using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Lab24_Aksana.Patrubeika_EFComponents.Models
{
    public class Trip
    {
        [Key]
        [Column("TripID")]
        public int TripId { get; set; }


        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }

        [DataMember]
        public string Plane { get; set; }

        [DataMember]
        public string TownFrom { get; set; }

        [DataMember]
        public string TownTo { get; set; }
    }
}
