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
    public interface ICategoryService
    {
        public Task<ServiceResult> ViewAllCategory();
        public Task<ServiceResult> AddCategory(CategoryAdd key);
        public Task<ServiceResult> UpdateCategory(CategoryUpdate key);
        public Task<ServiceResult> DeteleCategory(int CategoryId);
    }
}
