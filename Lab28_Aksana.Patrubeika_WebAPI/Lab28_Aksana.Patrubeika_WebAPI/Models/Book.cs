using System.ComponentModel.DataAnnotations;

namespace Lab28_Aksana.Patrubeika_WebAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public string Year { get; set; }

        public decimal Price { get; set; }

        public string Ganre { get; set; }
    }
}
