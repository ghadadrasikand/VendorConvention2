using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendorConvention.DTOs
{
    public class TagUpdateDTO
    {
        public int id { get; set; }
        [Required, StringLength(128)]
        public string Name { get; set; }
    }
}
