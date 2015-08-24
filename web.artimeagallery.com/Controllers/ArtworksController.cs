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
    public class ArtworksController : Controller
    {
        private ArtemiaContext db = new ArtemiaContext();

        public ArtworksController()
        {
            ViewBag.Types = db.ArtworkTypes.ToList().Select(x =>
       new SelectListItem
       {
           Text = x.Name,
           Value = x.Id.ToString()
       }).ToList();


            ViewBag.Artists = db.Artists.ToList().Select(x =>
     new SelectListItem
     {
         Text = x.FirstName + " " + x.LastName,
         Value = x.Id.ToString()
     }).ToList();
        }
        // GET: Artworks
        public ActionResult Index()
        {
            return View(db.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).OrderByDescending(x => x.Id).ToList());
        }

        // GET: Artworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).First(x => x.Id == id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return View(artwork);
        }

        // GET: Artworks/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Artworks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Artwork artwork)
        {
            if (ModelState.IsValid)
            {
                var artist = db.Artists.First(x => x.Id == artwork.Artist.Id);

                var art = (List<ArtworkViewModel>)Session["uploads"];

                var artToAdd = new List<Artwork>();

                if (art.Count > 0)
                {
                    foreach (var a in art)
                    {
                        a.Artwork.ForSale = true;
                        a.Artwork.Artist = artist;
                        db.Artworks.Add(a.Artwork);
                    }
                }


                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artwork);
        }

        // GET: Artworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).First(x => x.Id == id);
            if (artwork == null)
            {
                return HttpNotFound();
            }

            ViewBag.Types = db.ArtworkTypes.ToList().Select(x =>
            new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return View(artwork);
        }

        // POST: Artworks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Artwork artwork)
        {
            var previous = db.Artworks.Find(artwork.Id);
            previous.Description = artwork.Description;
            previous.Title = artwork.Title;
            previous.Price = artwork.Price;
            previous.Material = artwork.Material;
            previous.Size = artwork.Size;

            previous.ArtworkType = new ArtworkType
            {
                Id = artwork.ArtworkType.Id
            };


            if (ModelState.IsValid)
            {
                db.Entry(previous).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artwork);
        }

        // GET: Artworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Find(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return View(artwork);
        }

        // POST: Artworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artwork artwork = db.Artworks.Include(x => x.Artist).Include(x => x.ArtworkType).First(x => x.Id == id);
            db.Artworks.Remove(artwork);
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
