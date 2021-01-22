using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendorConvention.DTOs
{
    public class GridResultDTO
    {
        public GridResultDTO()
        {
            Tag = new HashSet<TagDTO>();
        }
        public int Id { get; set; }
        public string VendorName { get; set; }
        [Required, StringLength(128)]
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Date { get; set; }
        public ICollection<TagDTO> Tag { get; set; }
    }
}
