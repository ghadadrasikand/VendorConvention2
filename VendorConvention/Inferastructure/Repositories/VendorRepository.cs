using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using VendorConvention.Contexts;
using VendorConvention.Inferastructure.IRepositories;
using VendorConvention.Models;

namespace VendorConvention.Inferastructure.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly VendorContext _db;
        public VendorRepository(VendorContext db)
        {
            _db = db;
        }

        public List<Vendor> GetAll()
        {
            /* var query= (from v in _db.Vendor
                     join t in _db.Tag
                     on v.Id equals t.VendorId select v).ToList();*/
            

             return _db.Vendor.Include(x=>x.Tag).ToList();
        }
        public List<Tag> GetAllTags(int id)
        {
          return  _db.Tag.Where(x => x.VendorId == id).ToList();
        }
        public int Insert(Vendor vendor)
        {
            _db.Vendor.Add(vendor);
            return _db.SaveChanges();
        }
        public int Update(Vendor vendor)
        {
            _db.Vendor.Update(vendor);
            return _db.SaveChanges();

        }
        public Vendor GetById(int id)
        {
            return _db.Vendor.Where(x=>x.Id==id).Include(t=>t.Tag).FirstOrDefault();
        }
        public int Delete(int id)
        {
            var vendor= _db.Vendor.Where(x => x.Id == id).Include(t => t.Tag).FirstOrDefault();
            _db.Vendor.Remove(vendor);
            return _db.SaveChanges();
        }
        public int UpdatePatch(int id, JsonPatchDocument<Vendor> patchEntity)
        {
            
            var vendor = _db.Vendor.Where(x => x.Id == id).Include(t => t.Tag).FirstOrDefault();
            //var ModelState = State.ModelState1;
            patchEntity.ApplyTo(vendor);
            return _db.SaveChanges();
        }

        
    }
}
