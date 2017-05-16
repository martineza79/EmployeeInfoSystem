using EmployeeInfoSystem.BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfoSystem.DAL
{
    public class RoleDb : DALBase
    {
        // Commented code [db initialization] is inherited from DALBase class 
        //private EISDBContext db;

        //public RoleDb()
        //{
        //    db = new EISDBContext();
        //}

        public IEnumerable<Role> GetAll()
        {
            return db.Roles.ToList();
        }
        public Role GetByID(int Id)
        {
            return db.Roles.Find(Id);
        }
        public void Insert(Role role)
        {
            db.Roles.Add(role);
            Save();
        }
        public void Delete(int Id)
        {
            Role role = db.Roles.Find(Id);
            db.Roles.Remove(role);
            Save();
        }
        public void Update(Role role)
        {
            db.Entry(role).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false; // bool property from the DbContectConfiguration class
            Save();
            db.Configuration.ValidateOnSaveEnabled = true; // false = drop data validation before, then true when enable after Save()
        }
        public void Save()
        {
            db.SaveChanges();
        }        
    }
}
