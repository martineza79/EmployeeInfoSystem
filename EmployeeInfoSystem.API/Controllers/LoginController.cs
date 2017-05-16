using EmployeeInfoSystem.BLL;
using EmployeeInfoSystem.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace EmployeeInfoSystem.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class LoginController : ApiController
    {
        EmployeeBs employeeObjBs;

        public LoginController()
        {
            employeeObjBs = new EmployeeBs();
        }

        [ResponseType(typeof(EmployeeBs))]
        public IHttpActionResult Post(Employee emp)
        {
            if (employeeObjBs.GetByEmail(ref emp))
            {
                return Ok(emp);
            }
            else
            {
                foreach (var error in employeeObjBs.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState);
            }
        }
    }
}
