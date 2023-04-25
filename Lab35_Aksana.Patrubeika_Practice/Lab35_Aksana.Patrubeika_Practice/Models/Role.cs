namespace Lab35_Aksana.Patrubeika_Practice.Models
{
    public class Role
    {       
        public int RoleId { get; set; }

        public string RoleName { get; set; } = null!;

        public int? RoleSalary { get; set; }

        public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
    }
}
