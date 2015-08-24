using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace web.artimeagallery.com.Models
{
    public class Artwork
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public byte[] Bytes { get; set; }
        public byte[] ResizedBytes { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public bool ForSale { get; set; }
        public DateTime WhenCreated { get; set; }
        public string Orientation { get; set; }
        public virtual ArtworkType ArtworkType { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
