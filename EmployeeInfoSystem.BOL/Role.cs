using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfoSystem.BOL
{
    [Table("Role")]
    public partial class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleCode {get;set;}
        //public string RoleDescription { get; set; } // New feature that needs Entity Framework Code First Migration

        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}
