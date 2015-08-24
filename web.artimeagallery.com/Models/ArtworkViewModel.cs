using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.artimeagallery.com.Models
{
  
    public class ArtworkViewModel
    {
        public Guid Guid { get; set; }
        public Artwork Artwork { get; set; }
        public int Count { get; set; }
    }
}
