using EmployeeInfoSystem.BOL;
using EmployeeInfoSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfoSystem.BLL
{
    public class EmployeeBs
    {
        private EmployeeDb ObjDb;

        public List<string> Errors = new List<string>();

        public EmployeeBs()
        {
            ObjDb = new EmployeeDb();
        }

        public IEnumerable<Employee> GetAll()
        {
            return ObjDb.GetAll();
        }

        public Employee GetByID(string Id)
        {
            return ObjDb.GetByID(Id);
        }

        public bool Insert(Employee emp)
        {
            if (IsValidOnInsert(emp))
            {
                ObjDb.Insert(emp);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(string Id)
        {
            ObjDb.Delete(Id);
        }

        public bool Update(Employee emp)
        {
            if(IsValidOnUpdate(emp))
            {
                ObjDb.Update(emp);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetByEmail(ref Employee emp)
        {
            var employee = ObjDb.GetByEmail(emp.Email);
            if (employee == null)
            {
                Errors.Add("Email does not exist");
            }
            else if (employee.Password != emp.Password)
            {
                Errors.Add("Invalid Password");
            }

            if (Errors.Count() == 0)
            {
                emp = employee;
                return true;
            }
            else
                return false;
        }

        //public Employee RecoverPasswordByEmail(string email)
        //{
        //    var emp = ObjDb.GetByEmail(email);
        //    return emp;
        //}

        public bool IsValidOnInsert(Employee emp)
        {
            // Unique EmployeeID validation
            string EmployeeIdValue = emp.EmployeeId.ToString();
            int count = GetAll().Where(x => x.EmployeeId == EmployeeIdValue).ToList().Count();
            if (count != 0)
            {
                Errors.Add("EmployeeId Already Exist");
            }

            // Unique Email validation
            string EmailValue = emp.Email.ToString();
            count = GetAll().Where(x => x.Email == EmailValue).ToList().Count();
            if (count != 0)
            {
                Errors.Add("Email Already Exists");
            }

            if (Errors.Count() == 0)
                return true;
            else
                return false;
        }

        public bool IsValidOnUpdate(Employee emp)
        {
            var TotalExpValue = emp.TotalExp;
            var RelevantExpValue = emp.RelevantExp;

            if (RelevantExpValue > TotalExpValue)
            {
                Errors.Add("Total Exp should be greater than Relevant Exp");
            }
            if (Errors.Count() == 0)
                return true;
            else
                return false;
        }

    }
}
