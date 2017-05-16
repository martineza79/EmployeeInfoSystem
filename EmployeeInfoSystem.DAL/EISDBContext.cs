using EmployeeInfoSystem.BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfoSystem.DAL
{
    public class EISDBContext : DbContext
    {
        public EISDBContext() : base("EmployeeInformationSystemDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EISDBContext, Migrations.Configuration>()); // This code is necessary after "Enable-Migrations" command
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
