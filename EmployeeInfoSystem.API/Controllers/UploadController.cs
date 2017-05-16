using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeInfoSystem.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UploadController : ApiController
    {
        public HttpResponseMessage Post(string Id)
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/Files/ProfilePics/" + Id + ".jpeg");
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                }
                //result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
                return GetFile(Id);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        private static HttpResponseMessage GetFile(string Id)
        {
            var filePath = HttpContext.Current.Server.MapPath("~/Files/ProfilePics/");
            Byte[] b;
            if (File.Exists(filePath + Id + ".jpeg"))
            {
                b = File.ReadAllBytes(filePath + Id + ".jpeg");
            }
            else
            {
                b = File.ReadAllBytes(filePath + "anonymous.jpg");
            }

            HttpResponseMessage Response = new HttpResponseMessage(HttpStatusCode.OK);
            Response.Content = new StringContent(Convert.ToBase64String(b));
            Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return Response;
        }

        public HttpResponseMessage Get(string Id)
        {
            return GetFile(Id);
        }
    }
}
