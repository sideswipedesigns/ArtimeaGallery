using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.artimeagallery.com.Models;

namespace web.artimeagallery.com.Controllers
{
    public class HomeController : Controller
    {
        ArtemiaContext _db = new ArtemiaContext();

        public ActionResult Index()
        {
            return RedirectToAction("ArtistListing");

            var model = _db.BusinessInformations.FirstOrDefault();
            return View(model);
        }

        public ActionResult GalleryIndex()
        {
            var artworks = _db.Artworks.Include(x => x.Artist).Where(x => x.ForSale).ToList();

            var model = _db.Artists
                .Where(x => x.Enabled);

            foreach (var artist in model)
            {
                artist.Artworks = artworks.Where(x => x.Artist.Id == artist.Id).ToList();
            }

            return View(model);
        }

        public ActionResult ArtistListing()
        {
            var art = _db.Artworks.Include(x => x.Artist).Where(x => x.ForSale == true).ToList();

            var model = _db.Artists.Where(x => x.Enabled).ToList();

            foreach (var artist in model)
            {
                artist.Artworks = art
                    .Where(x => x.Artist.Id == artist.Id)
                    .ToList();
            }

            return View(model);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            var model = _db.BusinessInformations.FirstOrDefault();
            return View(model);
        }

        public string MailingListSignup(MailingList signup)
        {
            if (ModelState.IsValid)
            {
                var ok = _db.MailingLists.Add(signup);
                _db.SaveChanges();
                return "OK";
            }

            return "Not OK";
        }
    }
}