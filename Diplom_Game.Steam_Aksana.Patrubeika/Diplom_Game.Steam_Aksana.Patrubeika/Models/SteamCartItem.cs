using System.ComponentModel.DataAnnotations;

namespace Diplom_Game.Steam_Aksana.Patrubeika.Models
{
    public class SteamCartItem
    {
        //класс отвечает за товары в корзине
        [Key]
        public int ItemId { get; set; }
        public Game Game { get; set; }
        public double Price { get; set; }

        public string SteamCartId { get; set; }
    }
}
