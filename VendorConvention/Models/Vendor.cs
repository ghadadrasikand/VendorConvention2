using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendorConvention.Models
{
    public class Vendor
    {
        public Vendor()
        {
            Tag = new HashSet<Tag>();
        }
        public int Id { get; set; }
        [Required, StringLength(128)]
        public string VendorName { get; set; }
        [Required, StringLength(128)]
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Tag> Tag { get; set; }
    }
}
