using Diplom_Game.Steam_Aksana.Patrubeika.Models;

namespace Diplom_Game.Steam_Aksana.Patrubeika.ViewModel
{
    public class EditUserProfileAccountViewModel
    {
        public string Id { get; set; }

        public Guid SteamId { get; set; }
       
        public string SteamName { get; set; }

        public int? Age { get; set; }

        public string Country { get; set; }

        public int? UserLevelId { get; set; }

        public int? GameId { get; set; }

        public string? Img { get; set; }
    }
}
