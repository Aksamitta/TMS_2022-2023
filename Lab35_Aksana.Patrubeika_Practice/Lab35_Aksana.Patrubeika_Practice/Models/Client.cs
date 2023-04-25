namespace Lab35_Aksana.Patrubeika_Practice.Models
{
    public class Client
    {        
        public int ClientId { get; set; }

        public string ClientName { get; set; } = null!;

        public string ClientSname { get; set; } = null!;

        public virtual ICollection<Magazine> Magazines { get; } = new List<Magazine>();
    }
}
