using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using extension.railgunit.com.Image;
using web.artimeagallery.com.Models;

namespace web.artimeagallery.com.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload

        public ActionResult UploadArtistImage()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                var existingBlob = (byte[])Session["uploadedArtistImage"] ?? new byte[0];

                BinaryReader b = new BinaryReader(file.InputStream);
                byte[] binData = b.ReadBytes(file.ContentLength);

                byte[] resizedImage;

                //resizedImage = ImageResizer.ResizeJpgFixedHeight(binData, 400);

                Session["uploadedArtistImage"] = binData;


            }
            return Json("Ok");
            
        }

        public ActionResult Upload()
        {
            var latestFile = new Artwork();
            var vm = new ArtworkViewModel();

            for (int i = 0; i < Request.Files.Count; i++)
            {

                var existingBlobs = (List<ArtworkViewModel>)Session["uploads"] ?? new List<ArtworkViewModel>();

                var file = Request.Files[i];

                BinaryReader b = new BinaryReader(file.InputStream);
                byte[] binData = b.ReadBytes(file.ContentLength);

                var thumbnail =new byte[0];


                byte[] resizedImage;

                var size = ImageResizer.GetHeightAndWidth(binData);
                var orientation = ImageResizer.GetOrientation(binData);

                if (orientation == "landscape")
                {
                    thumbnail = ImageResizer.ResizeJpg(binData, 270, 200);

                }
                else
                {

                    
                    thumbnail = ImageResizer.ResizeJpgFixedWidth(binData, 270);
                    thumbnail = ImageResizer.CropJpg(thumbnail, new Rectangle(0, 0, 270, 200));
                    //now crop

                }

                //need to make sure it's not too big
                if (size.Width > 1024)
                {
                    binData = ImageResizer.ResizeJpgFixedWidth(binData, 1024);
                }

                latestFile = new Artwork
                {
                    FileName = file.FileName.Split('.')[0],
                    Extension = "." + file.FileName.Split('.')[1],
                    Bytes = binData,
                    ResizedBytes = thumbnail,
                    WhenCreated = DateTime.Now,
                    Orientation = orientation,
                    ForSale = true
                };


                Session["uploads"] = existingBlobs;

                if (Session["uploadsCount"] == null)
                {
                    Session["uploadsCount"] = 0;
                }
                else
                {
                    var existingCount = (int)Session["uploadsCount"];
                    Session["uploadsCount"] = existingCount++;
                }


                vm = new ArtworkViewModel
                {
                    Artwork = latestFile,
                    Count = (int)Session["uploadsCount"]
                };

                existingBlobs.Add(vm);

                Session["uploads"] = existingBlobs;
            }



            return Json("Ok");

        }
    }
}