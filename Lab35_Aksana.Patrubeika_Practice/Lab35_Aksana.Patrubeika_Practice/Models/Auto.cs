using static System.Net.Mime.MediaTypeNames;

namespace Lab35_Aksana.Patrubeika_Practice.Models
{
    public class Auto
    {       
        public int AutoId { get; set; }

        public string AutoModel { get; set; } = null!;

        public int Year { get; set; }

        public decimal Price { get; set; }

        public string? Status { get; set; }

        public virtual ICollection<Order> Orders { get; } = new List<Order>();

        public virtual ICollection<Magazine> Magazines { get; } = new List<Magazine>();
    }
}
