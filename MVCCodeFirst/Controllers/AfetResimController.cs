using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCCodeFirst.Context;
using MVCCodeFirst.Models;

namespace MVCCodeFirst.Controllers
{
    public class AfetResimController : Controller
    {

        private SaldemContext db = new SaldemContext();

        // GET: AfetResim
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ContentResult UploadFiles(int? id)
        {
            var r = new List<UploadFilesResult>();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                if (hpf.ContentLength == 0)
                    continue;


                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(hpf.InputStream))
                {
                    fileData = binaryReader.ReadBytes(hpf.ContentLength);
                }

                AfetResim resim = new AfetResim();
                resim.Afet = db.Afet.FirstOrDefault(a => a.Id == id);
                resim.Data = fileData;
                db.AfetResim.Add(resim);
                db.SaveChanges();

                r.Add(new UploadFilesResult()
                {
                    Name = hpf.FileName,
                    Length = hpf.ContentLength,
                    Type = hpf.ContentType
                });
            }
            return Content("{\"name\":\"" + r[0].Name + "\",\"type\":\"" + r[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", r[0].Length) + "\"}", "application/json");
        }


        public ActionResult GetThumnail(int? id)
        {
            AfetResim resim = db.AfetResim.Find(id);
            if (resim != null)
            {
                byte[] imageData = resim.Data;
                return File(imageData, "image/jpeg");
            }
            return null;
        }

        [HttpPost]
        public ActionResult DeleteResim(int? id)
        {
            AfetResim resim = db.AfetResim.Find(id);
            if (resim != null)
            {
                db.AfetResim.Remove(resim);
                db.SaveChanges();
            }
            return Content("{\"result\":\"true\"}", "application/json");
        }

        public ActionResult LoadAfetResimView(int id)
        {
            Afet afet = db.Afet.Find(id);
            if (afet != null)
            {
                afet.AfetResim = db.AfetResim.Where(a => a.Afet != null && a.Afet.Id == id).ToList();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return PartialView("AfetResimList", afet);
        }
    }
}