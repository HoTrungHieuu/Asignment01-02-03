using BussinessObject.AddModel;
using BussinessObject.UpdateModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ITagService
    {
        public Task<ServiceResult> ViewAllTag();
        public Task<ServiceResult> AddTag(TagAdd key);
        public Task<ServiceResult> UpdateTag(TagUpdate key);
        public Task<ServiceResult> DeteleTag(int tagId);
        public Task<ServiceResult> ViewTagDetail(short tagId);
    }
}
