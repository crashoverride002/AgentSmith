using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeoMask.Models;

namespace GeoMask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

   
        public JsonResult UploadPic()
        {

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                //Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("~/MaskPics/") + fileName); //File will be saved in application root
            }

            // JsonRequestBehavior.AllowGet;

            return Json("Uploaded " + Request.Files.Count + " files");
      
        }

        public ActionResult About()
        {
            ViewBag.Message = "Upload your GeoMask Image.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Map.";

            List<MaskLocation> rtn = new List<MaskLocation>();

            //25.1972018, lng: 55.2721877

            rtn.Add(new MaskLocation() { latitude = "25.1972018", longitude = "55.2721877", name = "Agent Smith" });

            return View(rtn);
        }
    }
}
