using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Models
{
    public class Game
    {
        public int GameId { get; set; }

        public string GameName { get; set; }

        public int DeveloperId { get; set; }
       
        //keep name of an image
        public string? Img { get; set; }

        //keep path of an image
        public string? ImgPath { get; set; }
  
        public DateTime ReleaseDate { get; set; }

        public string Reviews { get; set; }

        public string Genre { get; set; }

        public string? Summary { get; set; }

        public double Price { get; set; }

        public virtual Developer? Developer { get; set; }

        public virtual ICollection<SteamCartItem> Games { get; } = new List<SteamCartItem>();

    }
}
