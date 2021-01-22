using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VendorConvention.Models;

namespace VendorConvention.DTOs
{
    public class TagInsertDTO
    {
        
        [Required, StringLength(128)]
        public string Name { get; set; }
      
    }
}
