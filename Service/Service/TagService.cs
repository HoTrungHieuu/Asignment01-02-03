using BussinessObject.AddModel;
using BussinessObject.UpdateModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using Repository.IRepository;
using Repository.Repository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class TagService : ITagService
    {
        public ITagRepository tagRepository;
        public TagService()
        {
            this.tagRepository = new TagRepository();
        }
        public async Task<ServiceResult> ViewAllTag()
        {
            try
            {
                var tags = await tagRepository.ViewAllTag();
                return new ServiceResult
                {
                    Status = 200,
                    Message = "List Tags",
                    Data = tags
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Status = 501,
                    Message = ex.ToString(),
                };
            }
        }
        public async Task<ServiceResult> AddTag(TagAdd key)
        {
            try
            {
                var tag = await tagRepository.AddTag(key);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Create Tag Success",
                    Data = tag
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Status = 501,
                    Message = ex.ToString(),
                };
            }
        }
        public async Task<ServiceResult> UpdateTag(TagUpdate key)
        {
            try
            {
                var tag = await tagRepository.UpdateTag(key);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Update Tag Success",
                    Data = tag
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Status = 501,
                    Message = ex.ToString(),
                };
            }
        }
        public async Task<ServiceResult> DeteleTag(int tagId)
        {
            try
            {
                var tag = tagRepository.GetById(tagId);
                if(tag == null)
                {
                    return new ServiceResult
                    {
                        Status = 404,
                        Message = "Tag Not Found",
                    };
                }
                await tagRepository.RemoveAsync(tag);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Delete Success",
                    Data = tag
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Status = 501,
                    Message = ex.ToString(),
                };
            }
        }
    }
}
