using EmployeeInfoSystem.BLL;
using EmployeeInfoSystem.BOL;
//using EmployeeInfoSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfoSystem.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            RoleBs R = new RoleBs(); // used when ...the ConsoleUI class library references ...BLL
            //RoleDb R = new RoleDb(); // used when the ...ConsoleUI class library references ...DAL
            //R.Insert(new Role() { RoleName="Admin", RoleCode="A"}); // used when the ...ConsoleUI class library references ...DAL
            R.Insert(new Role() { RoleName="User", RoleCode="U"});
            //R.Save(); // used when the ...ConsoleUI class library 
        }
    }
}
