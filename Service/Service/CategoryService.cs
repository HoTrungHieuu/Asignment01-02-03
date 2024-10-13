using BussinessObject.AddModel;
using BussinessObject.UpdateModel;
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
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository CategoryRepository;
        public CategoryService()
        {
            this.CategoryRepository = new CategoryRepository();
        }
        public async Task<ServiceResult> ViewAllCategory()
        {
            try
            {
                var Categorys = await CategoryRepository.ViewAllCategory();
                return new ServiceResult
                {
                    Status = 200,
                    Message = "List Categorys",
                    Data = Categorys
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
        public async Task<ServiceResult> ViewCategoryDetail(short categoryId)
        {
            try
            {
                var category = await CategoryRepository.GetCategoryDetail(categoryId);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Category",
                    Data = category
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
        public async Task<ServiceResult> AddCategory(CategoryAdd key)
        {
            try
            {
                var Category = await CategoryRepository.AddCategory(key);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Create Category Success",
                    Data = Category
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
        public async Task<ServiceResult> UpdateCategory(CategoryUpdate key)
        {
            try
            {
                var Category = await CategoryRepository.UpdateCategory(key);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Update Category Success",
                    Data = Category
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
        public async Task<ServiceResult> DeteleCategory(int CategoryId)
        {
            try
            {
                var Category = CategoryRepository.GetById(CategoryId);
                if (Category == null)
                {
                    return new ServiceResult
                    {
                        Status = 404,
                        Message = "Category Not Found",
                    };
                }
                await CategoryRepository.RemoveAsync(Category);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Delete Success",
                    Data = Category
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
