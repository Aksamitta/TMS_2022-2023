using System.ComponentModel.DataAnnotations;

namespace Lab28_Aksana.Patrubeika_WebAPI.Models
{
    public class AddBooksViewModel
    {
        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public string Ganre { get; set; }
    }
}
