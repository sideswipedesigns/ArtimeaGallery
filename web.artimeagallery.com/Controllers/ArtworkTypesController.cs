using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web.artimeagallery.com.Models;

namespace web.artimeagallery.com.Controllers
{
    public class ArtworkTypesController : Controller
    {
        private ArtemiaContext db = new ArtemiaContext();

        // GET: ArtworkTypes
        public ActionResult Index()
        {
            return View(db.ArtworkTypes.ToList());
        }

        // GET: ArtworkTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtworkType artworkType = db.ArtworkTypes.Find(id);
            if (artworkType == null)
            {
                return HttpNotFound();
            }
            return View(artworkType);
        }

        // GET: ArtworkTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtworkTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ArtworkType artworkType)
        {
            if (ModelState.IsValid)
            {
                db.ArtworkTypes.Add(artworkType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artworkType);
        }

        // GET: ArtworkTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtworkType artworkType = db.ArtworkTypes.Find(id);
            if (artworkType == null)
            {
                return HttpNotFound();
            }
            return View(artworkType);
        }

        // POST: ArtworkTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ArtworkType artworkType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artworkType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artworkType);
        }

        // GET: ArtworkTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtworkType artworkType = db.ArtworkTypes.Find(id);
            if (artworkType == null)
            {
                return HttpNotFound();
            }
            return View(artworkType);
        }

        // POST: ArtworkTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtworkType artworkType = db.ArtworkTypes.Find(id);
            db.ArtworkTypes.Remove(artworkType);
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
