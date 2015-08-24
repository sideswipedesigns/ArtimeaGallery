using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.artimeagallery.com.Models
{
    public class ArtworkType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Artwork> Artworks { get; set; }
    }
}
