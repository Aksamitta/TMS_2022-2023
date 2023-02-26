using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Lab23_Aksana.Patrubeika_ORM.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [DataMember]        //хз для чего
        public string PersonName { get; set; }

        [DataMember]        //хз для чего
        public int Age { get; set; }

        [DataMember]        //хз для чего
        public string Specialization { get; set; }
    }
}
