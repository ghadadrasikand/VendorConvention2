using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorConvention.DTOs;
using VendorConvention.Inferastructure.IRepositories;
using VendorConvention.Models;

namespace VendorConvention.ApplicationServices.IServices
{
    public interface IVendorService
    {
        List<GridResultDTO> GetAll();
        public bool Insert(VendorInsertDTO dto);
        public bool Update(int id,VendorUpdateDTO dto);
        public bool Delete(int id);
        public bool UpdatePatch(int id, JsonPatchDocument<Vendor> patchEntity);
        public GridResultDTO GetById(int id);

    }
}
