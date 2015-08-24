using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace web.artimeagallery.com.Models
{
    public class Location
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

    }
}