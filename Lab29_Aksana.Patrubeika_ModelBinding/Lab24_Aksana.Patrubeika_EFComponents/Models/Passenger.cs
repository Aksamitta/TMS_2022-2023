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

        [Required(ErrorMessage = "Field 'Name' is empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field 'Password' is empty!")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Password must be longer then 5 and shotter then 10 symbols, contains lower and upper letters register and numbers")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords does not equals")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        public string Birth { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public virtual ICollection<PassInTrip> PassInTrips { get; } = new List<PassInTrip>();
    }
}
