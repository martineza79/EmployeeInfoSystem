using EmployeeInfoSystem.BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfoSystem.DAL
{
    public class EmployeeDb : DALBase
    {
        // Commented code [db initialization] is inherited from DALBase class
        //private EISDBContext db;

        //public EmployeeDb()
        //{
        //    db = new EISDBContext();
        //}

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees.ToList();
        }

        public Employee GetByID(string Id)
        {
            return db.Employees.Find(Id);
        }

        public void Insert(Employee emp)
        {
            db.Employees.Add(emp);
            Save();
        }

        public void Delete(string Id)
        {
            Employee emp = db.Employees.Find(Id);
            db.Employees.Remove(emp);
            Save();
        }

        public void Update(Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public Employee GetByEmail(string email)
        {
            return db.Employees.Where(x => x.Email == email).Include("Role").FirstOrDefault();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
