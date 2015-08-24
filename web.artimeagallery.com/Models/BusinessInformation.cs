using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.artimeagallery.com.Models
{
    public class BusinessInformation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string About { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
