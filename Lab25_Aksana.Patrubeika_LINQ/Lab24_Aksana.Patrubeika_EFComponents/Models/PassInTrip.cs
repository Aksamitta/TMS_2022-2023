﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Lab24_Aksana.Patrubeika_EFComponents.Models
{
    public class PassInTrip
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }


        public int TripId { get; set; }
        public Trip? Trip { get; set; }

        [DataMember]
        [Column("PassengerID")]
        public int PassengerId { get; set; }
        public Passenger? Passenger { get; set; }
    }
}
