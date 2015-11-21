using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCCodeFirst.Context;
using MVCCodeFirst.Models;

namespace MVCCodeFirst.Controllers
{
    public class AfetController : Controller
    {
        private SaldemContext db = new SaldemContext();

        // GET: Afet
        public ActionResult Index()
        {
            return View(db.Afet.ToList());
        }

        // GET: Afet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afet afet = db.Afet.Find(id);
            if (afet == null)
            {
                return HttpNotFound();
            }

            afet.AfetResim = db.AfetResim.Where(a => a.Afet != null && a.Afet.Id == id).ToList();
            return View(afet);
        }

        // GET: Afet/Create
        public ActionResult Create()
        {
            ViewBag.AfetTurList = AddDefaultOption(new SelectList(db.AfetTur.ToList(), "Id", "Name"), "Seçiniz", "0");
            ViewBag.SehirList = AddDefaultOption(new SelectList(db.Sehir.ToList(), "Id", "Name"), "Seçiniz", "0");
            ViewBag.IlceList = new SelectList(new List<Ilce>(), "Id", "Name");
            return View();
        }

        private IEnumerable<SelectListItem> AddDefaultOption(IEnumerable<SelectListItem> list, string dataTextField, string selectedValue)
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = dataTextField, Value = selectedValue });
            items.AddRange(list);
            return items;
        }

        [HttpPost]
        public ActionResult GetIlceListBySehir(string sehirId)
        {

            int y = Convert.ToInt32(sehirId);
            return Json(new { ilceList = db.Ilce.Where(a => a.Sehir != null && a.Sehir.Id == y).ToList() });
        }

        // POST: Afet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SeriNo,BaslangicTarih,BitisTarih,Neden,Enlem,Boylam,Aciklama,EtkiledigiAlanlar,Kaynak")] Afet afet)
        {
            //if (ModelState.IsValid)
            //{
            if (Request.Form["AfetTuru"] != "0")
            {
                afet.AfetTuru = new AfetTur();
                afet.AfetTuru.Id = Convert.ToInt32(Request.Form["AfetTuru"]);
            }
            if (Request.Form["Sehir"] != "0")
            {
                afet.Sehir = new Sehir();
                afet.Sehir.Id = Convert.ToInt32(Request.Form["Sehir"]);
            }
            if (!String.IsNullOrEmpty(Request.Form["Ilce"]))
            {
                afet.Ilce = new Ilce();
                afet.Ilce.Id = Convert.ToInt32(Request.Form["Ilce"]);
            }

            db.Afet.Add(afet);
            db.SaveChanges();
            return RedirectToAction("Index");
            //}

            return View(afet);
        }

        // GET: Afet/Edit/5
        public ActionResult Edit(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afet afet = db.Afet.Find(id);

            if (afet == null)
            {
                return HttpNotFound();
            }

            ViewBag.AfetTurList = AddDefaultOption(new SelectList(db.AfetTur.ToList(), "Id", "Name"), "Seçiniz", "0");

            ViewBag.SehirList = AddDefaultOption(new SelectList(db.Sehir.ToList(), "Id", "Name"), "Seçiniz", "0");
            ViewBag.IlceList = new SelectList(new List<Ilce>(), "Id", "Name");

            //if (afet.AfetTuru != null)
            //{
            //    ((List<SelectListItem>)ViewBag.AfetTurList).First(a => a.Value == afet.AfetTuru.Id.ToString()).Selected = true;

            //}
            //if (afet.Sehir != null)
            //{
            //    ((List<SelectListItem>)ViewBag.SehirList).First(a => a.Value == afet.Sehir.Id.ToString()).Selected = true;
            //}



            afet.AfetResim = db.AfetResim.Where(a => a.Afet != null && a.Afet.Id == id).ToList();

            return View(afet);
        }

        // POST: Afet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SeriNo,BaslangicTarih,BitisTarih,Neden,Enlem,Boylam,Aciklama,EtkiledigiAlanlar,Kaynak")] Afet afet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(afet);
        }

        // GET: Afet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afet afet = db.Afet.Find(id);
            if (afet == null)
            {
                return HttpNotFound();
            }
            return View(afet);
        }

        // POST: Afet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Afet afet = db.Afet.Find(id);
            db.Afet.Remove(afet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
