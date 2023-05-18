using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Models
{
    public class User : IdentityUser
    {
        public Guid SteamId { get; set; }

        //сделать уникальным
        public string SteamName { get; set; }
        
        public int? Age { get; set; }

        public string Country { get; set; }

        public int? UserLevelId { get; set; }

        public int? GameId { get; set; }

        public virtual UserLevel UserLevel { get; set; } = null!;

        public virtual Game Game { get; set; } = null!;
    }
}
