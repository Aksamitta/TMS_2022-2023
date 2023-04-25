using System.Data;

namespace Lab35_Aksana.Patrubeika_Practice.Models
{
    public class Employee
    {        
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; } = null!;

        public int RoleId { get; set; }

        public virtual ICollection<Magazine> Magazines { get; } = new List<Magazine>();

        public virtual Role Role { get; set; } = null!;
    }
}
