using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Lab24_Aksana.Patrubeika_EFComponents.Models
{
    public class Company
    {

        [Key]
        [Column("CompanyID")]
        public int CompanyId { get; set; }

        [DataMember]
        public string CompanyName { get; set; }
    }
}
