using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.artimeagallery.com.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool Enabled { get; set; }
        public byte[] ArtistPhoto { get; set; }
        public ICollection<Exhibition> Exhibitions { get; set; } 
        public ICollection<Artwork> Artworks { get; set; }
    }
}

