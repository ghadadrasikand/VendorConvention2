using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorConvention.Models;

namespace VendorConvention.Contexts
{
    public class VendorContext:DbContext

    {
        public VendorContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Tag> Tag { get; set; }

    }
}
