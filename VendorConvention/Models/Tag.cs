using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendorConvention.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required, StringLength(128)]
        public string Name { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public bool IsDeleted { get; set; }

    }
}
