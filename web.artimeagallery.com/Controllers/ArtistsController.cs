using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using extension.railgunit.com.Image;
using web.artimeagallery.com.Models;

namespace web.artimeagallery.com.Controllers
{
    public class ArtistsController : Controller
    {
        private ArtemiaContext db = new ArtemiaContext();

        // GET: Artists

        public ActionResult ShowArtist(int Id)
        {
            var artist = db.Artists.Include(x => x.Artworks).First(x => x.Id == Id);

            return PartialView("~/Views/Partials/ShowArtist.cshtml", artist);
        }

        public ActionResult Index()
        {
            return View(db.Artists.ToList());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Artist artist, IEnumerable<Artwork> Artwork = null)
        {


            if (ModelState.IsValid)
            {
                artist.Enabled = true;

                //add artwork if any was uploaded
                var art = (List<ArtworkViewModel>)Session["uploads"];

                var artToAdd = new List<Artwork>();
                if (art != null && art.Count > 0)
                {
                    foreach (var a in art)
                    {
                        artToAdd.Add(a.Artwork);
                    }

                    artist.Artworks = artToAdd;
                }

                //check for image of artist
                var existingBlob = (byte[])Session["uploadedArtistImage"];
                if (existingBlob != null)
                {
                    artist.ArtistPhoto = existingBlob;
                }


                db.Artists.Add(artist);
                db.SaveChanges();



                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Artist artist)
        {
            if (ModelState.IsValid)
            {
               
                if (Session["uploadedArtistImage"] != null)
                {
                    artist.ArtistPhoto = (byte[]) Session["uploadedArtistImage"];
                }

                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
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
