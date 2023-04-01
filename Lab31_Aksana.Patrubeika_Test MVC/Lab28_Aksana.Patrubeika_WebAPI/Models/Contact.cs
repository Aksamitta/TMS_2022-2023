using System.ComponentModel.DataAnnotations;

namespace Lab28_Aksana.Patrubeika_WebAPI.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }  
        
        public string Phone { get; set; }

        public string Addres { get; set; }
    }
}
