namespace Diplom_Game.Steam_Aksana.Patrubeika.ViewModel
{
    public class CreateGameViewModel
    {
        public int GameId { get; set; }

        public string GameName { get; set; }

        public int DeveloperId { get; set; }

        public string? Img { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Reviews { get; set; }

        public string Genre { get; set; }

        public string? Summary { get; set; }

        public double Price { get; set; }
    }
}
