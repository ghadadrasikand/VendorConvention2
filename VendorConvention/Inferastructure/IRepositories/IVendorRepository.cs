using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorConvention.Models;

namespace VendorConvention.Inferastructure.IRepositories
{
    public interface IVendorRepository
    {
        public List<Vendor> GetAll();
        public List<Tag> GetAllTags(int id);
        public int Insert(Vendor vendor);
        public int Update(Vendor vendor);
        public Vendor GetById(int id);
        public int Delete(int id);
        public int UpdatePatch(int id, JsonPatchDocument<Vendor> patchEntity);
    }
}

