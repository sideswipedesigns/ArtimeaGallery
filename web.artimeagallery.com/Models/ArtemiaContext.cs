using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.artimeagallery.com.Models
{
    public class ArtemiaContext : DbContext
    {

        static ArtemiaContext()
        {
            Database.SetInitializer<ArtemiaContext>(null);
        }


        public ArtemiaContext() : base("Name=ArtemiaContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public IDbSet<Artist> Artists { get; set; }
        public IDbSet<Artwork> Artworks { get; set; }
        public IDbSet<ArtworkType> ArtworkTypes { get; set; }
        public IDbSet<BusinessInformation> BusinessInformations { get; set; }
        public IDbSet<Exhibition> Exhibitions { get; set; }
        public IDbSet<Location> Location { get; set; }
        public IDbSet<MailingList> MailingLists { get; set; }

    }
}
