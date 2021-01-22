using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorConvention.ApplicationServices.IServices;
using VendorConvention.DTOs;
using VendorConvention.Inferastructure.IRepositories;
using VendorConvention.Models;

namespace VendorConvention.ApplicationServices.Services
{
    public class VendorService:IVendorService
    {
        private readonly IVendorRepository _VendorRepository;
        public VendorService(IVendorRepository VendorRepository)
        {
            _VendorRepository = VendorRepository;
        }
        public List<GridResultDTO> GetAll()
        {
            var data= _VendorRepository.GetAll();
            var VendorDTO = data.Select(x => new GridResultDTO
            {
                Id = x.Id,
                VendorName = x.VendorName,
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                Date = x.Date,
                Tag = _VendorRepository.GetAllTags(x.Id).Select(y => new TagDTO {
                    Name = y.Name
                }).ToList()
            }).ToList();
            return VendorDTO;
        }
        public GridResultDTO GetById(int id) {
            var data = _VendorRepository.GetById(id);
           GridResultDTO  VendorDTO = new GridResultDTO()
            {
                Id = data.Id,
                VendorName = data.VendorName,
                Title = data.Title,
                IsDeleted = data.IsDeleted,
                Date = data.Date,
                Tag = _VendorRepository.GetAllTags(id).Select(y => new TagDTO
                {
                    Name = y.Name
                }).ToList()
            };
            return VendorDTO;
        }
        public bool Insert(VendorInsertDTO dto)
        {
            bool result = false;
            var tagList = new List<Tag>();
           if(dto.Tags!=null && dto.Tags.Count>0)
            {
                foreach (var Tags in dto.Tags)
                {
                    var tag = new Tag
                    {
                        Name = Tags.Name
                    };

                    tagList.Add(tag);
                }

            }


            var vendor = new Vendor()
            {
                VendorName = dto.VendorName,
                Title = dto.Title,
                IsDeleted = dto.IsDeleted,
                Date = dto.Date,
                Tag=tagList
                
            };

            int inserted = _VendorRepository.Insert(vendor);
            if (inserted > 0)
            {
                result = true;
            }
            return result;
        }
        public bool Update(int id,VendorUpdateDTO dto)
        {
            bool result = false;

            var vendor = _VendorRepository.GetById(id);
            var tagList = new List<Tag>();
            if (dto.Tags != null && dto.Tags.Count > 0)
            {
                foreach (var Tags in dto.Tags)
                {
                    var tag = new Tag
                    {
                        Id=Tags.id,
                        Name = Tags.Name
                    };

                    tagList.Add(tag);
                }

            }
            vendor.VendorName = dto.VendorName;
            vendor.Title = dto.Title;
            vendor.IsDeleted = dto.IsDeleted;
            vendor.Date = dto.Date;
            vendor.Tag = tagList;
            int updated = _VendorRepository.Update(vendor);
            if (updated > 0)
            {
                result=true;
            }
            return result;
        }
        public bool Delete(int id)
        {
            bool result = false;

           
            int deleted = _VendorRepository.Delete(id);
            if (deleted > 0)
            {
                result = true;
            }
            return result;
        }
        public bool UpdatePatch(int id, JsonPatchDocument<Vendor> patchEntity)
        {
            bool result = false;
            int patch= _VendorRepository.UpdatePatch(id, patchEntity);
            if(patch>0)
            {
                result = true;
            }
            return result;
          
        }
    }
}
