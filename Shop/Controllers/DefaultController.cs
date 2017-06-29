using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;


namespace Shop.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default


        public ActionResult Index()
        {

            return View();

        }

        [HttpPost]
        public ContentResult delete()
        {
            string fullname2 = Request["key"];
            Console.WriteLine(fullname2);
            return Content("0");
        }

        [HttpPost]
        public ContentResult UploadFiles()
        {
            string v1 = " ";
            string review = " ";
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;
                string filePath = Guid.NewGuid() + Path.GetExtension(hpf.FileName);

                string savedFileName = Path.Combine(Server.MapPath("~/Assert/images/"), filePath);
                hpf.SaveAs(savedFileName);
                review += " \"<img src=\'../Assert/images/" + filePath + "\' height=\'120px\' class=\'file-preview-image\'>\",";
                v1 += "{ \"caption\" : \"../Assert/images/" + filePath + "\",\"height\":\"120px\",\"url\":\"/Upload2/delete\",\"key\":\"ID1\"},";

            }

            string rt = "{ \"file_id\": 0  ,"
                        + " \"overwriteInitial\" : true ,"
                        + " \"initialPreviewConfig\" : [ " + v1.Substring(0, v1.Length - 1) + " ],"
                        + "  \"initialPreview\" : [" + review.Substring(0, review.Length - 1) + "]"
                        + "}";
            return Content("" + rt + "", "application/json");
        }

    }
}