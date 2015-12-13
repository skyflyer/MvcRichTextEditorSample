using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Redactor.Controllers
{
    public class RedactorController : Controller
    {
        const string StoragePath = "~/App_Data/Redactor";

        // TODO: this is for demo purposes only
        // you should check authorization here!

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var dir = HostingEnvironment.MapPath(StoragePath);
            var filename = file.FileName;
            while(System.IO.File.Exists(Path.Combine(dir, filename)))
            {
                filename = "_" + filename;
            }
            file.SaveAs(Path.Combine(dir, filename));

            return Json(new { filelink = Url.RouteUrl("RedactorResource", new { filename = filename }) });
        }

        public ActionResult Get(string filename)
        {
            var path = Path.Combine(HostingEnvironment.MapPath(StoragePath), filename);
            if (!System.IO.File.Exists(path))
            {
                return HttpNotFound();
            }

            return File(path, MimeMapping.GetMimeMapping(filename));
        }
    }
}