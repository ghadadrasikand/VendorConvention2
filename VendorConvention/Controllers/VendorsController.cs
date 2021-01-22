using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorConvention.ApplicationServices.IServices;
using VendorConvention.DTOs;
using VendorConvention.Inferastructure.IRepositories;
using VendorConvention.Models;

namespace VendorConvention.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService VendorService;
    
        public VendorsController(IVendorService vendorService)
        {
            VendorService = vendorService;
         
        }

        [HttpGet("{id}")]
        public IActionResult GetAll([FromRoute] int id)
        {
           var result= VendorService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Insert(VendorInsertDTO dto)
        {
            var result = VendorService.Insert(dto);
            if (result)
            {
                return Ok();
            }
            else
            {
                throw new Exception();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id,VendorUpdateDTO dto)
        {
            bool result = VendorService.Update(id,dto);
            if (result)
            {
                return Ok();
            }
            else
            {
                throw new Exception();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            bool result = VendorService.Delete(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                throw new Exception();
            }
        }
        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id,JsonPatchDocument<Vendor> vendor)
        {
            bool result = VendorService.UpdatePatch(id,vendor);
            if (result)
            {
                return Ok();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
