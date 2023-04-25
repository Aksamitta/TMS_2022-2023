using static System.Net.Mime.MediaTypeNames;

namespace Lab35_Aksana.Patrubeika_Practice.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public int AutoId { get; set; }

        public string Status { get; set; } = null!;

        public virtual Auto Auto { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
