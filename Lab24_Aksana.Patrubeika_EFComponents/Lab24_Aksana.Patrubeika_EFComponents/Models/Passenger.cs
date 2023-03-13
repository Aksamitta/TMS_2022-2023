using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Lab24_Aksana.Patrubeika_EFComponents.Models
{
    public class Passenger
    {
        [Key]
        [Column("PassengerID")]
        public int PassengerId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
