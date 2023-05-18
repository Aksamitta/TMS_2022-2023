namespace Diplom_Game.Steam_Aksana.Patrubeika.Models
{
    public class Developer
    {
        public int DeveloperId { get; set; }

        public string DeveloperName { get; set; }

        public string DeveloperSummary { get; set; }

        public virtual ICollection<Game> Games { get; } = new List<Game>();
    }
}
