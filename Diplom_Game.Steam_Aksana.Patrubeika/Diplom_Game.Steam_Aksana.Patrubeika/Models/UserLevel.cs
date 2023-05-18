namespace Diplom_Game.Steam_Aksana.Patrubeika.Models
{
    public class UserLevel
    {
        public int UserLevelId { get; set; }

        public string LevelName { get; set; } = null!;

        public virtual ICollection<User> Users { get; } = new List<User>();
    }
}
