using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.artimeagallery.com.Models
{
    public class Exhibition
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Details { get; set; }
        public string OpeningTimes { get; set; }
        public decimal Cost { get; set; }
        public ICollection<Artist> Artists { get; set; }
        public virtual Location Location { get; set; }
    }
}
