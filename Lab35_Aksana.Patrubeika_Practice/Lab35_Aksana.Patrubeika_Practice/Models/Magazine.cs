namespace Lab35_Aksana.Patrubeika_Practice.Models
{
    public class Magazine
    {        
        public int MagazineId { get; set; }

        public int ClientId { get; set; }

        public int AutoId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public virtual Auto Auto { get; set; } = null!;

        public virtual Client Client { get; set; } = null!;

        public virtual Employee Employee { get; set; } = null!;
    }
}
