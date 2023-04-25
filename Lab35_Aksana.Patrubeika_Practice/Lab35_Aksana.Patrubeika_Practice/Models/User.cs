using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Lab35_Aksana.Patrubeika_Practice.Models
{
    public class User : IdentityUser
    {       

        public virtual ICollection<Order> Orders { get; } = new List<Order>();
    }
}
