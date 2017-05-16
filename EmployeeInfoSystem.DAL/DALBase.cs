using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfoSystem.DAL
{
    public class DALBase
    {
        protected EISDBContext db; // "protected" because I want to use it in the inherited classes

        public DALBase()
        {
            db = new EISDBContext();
        }
    }
}
