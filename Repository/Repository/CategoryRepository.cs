using BussinessObject.AddModel;
using BussinessObject.UpdateModel;
using BussinessObject.ViewModel;
using DataAccessObject.Models;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repository.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository()
        {

        }
        public async Task<List<CategoryView>> ViewAllCategory()
        {
            try
            {
                var listCategory = await GetAllAsync();
                return ConvertListCategoryToListCategoryView(listCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<CategoryView>> GetListCategorySearchPaging(string name, int sizePaging, int indexPaging)
        {
            try
            {
                var listCategory = (await GetAllAsync()).FindAll(l => l.CategoryName.ToLower().Contains(name.ToLower()));
                listCategory = Paging(listCategory, sizePaging, indexPaging);
                return ConvertListCategoryToListCategoryView(listCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CategoryView> AddCategory(CategoryAdd key)
        {
            try
            {
                var lastCategory = (await GetAllAsync()).Last();
                short newId = 1;
                if (lastCategory != null)
                {
                    newId = Convert.ToInt16(lastCategory.CategoryId + 1);
                }
                Category Category = new()
                {
                    CategoryId = newId,
                    CategoryName = key.CategoryName,
                    CategoryDesciption = key.CategoryDesciption,
                    ParentCategoryId = key.ParentCategoryId,
                    IsActive = true
                };
                await CreateAsync(Category);
                CategoryView result = new();
                result.ConvertCategoryToCategoryView(Category);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CategoryView?> UpdateCategory(CategoryUpdate key)
        {
            try
            {
                var category = GetById(key.Id);
                if (category == null)
                {
                    return null;
                }
                category.CategoryName = key.CategoryName;
                category.CategoryDesciption = key.CategoryDesciption;
                category.ParentCategoryId = key.ParentCategoryId;
                category.IsActive = key.IsActive;
                await UpdateAsync(category);
                CategoryView result = new();
                result.ConvertCategoryToCategoryView(category);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private List<CategoryView> ConvertListCategoryToListCategoryView(List<Category> listCategory)
        {
            List<CategoryView> results = new();
            foreach (var item in listCategory)
            {
                CategoryView resutl = new();
                resutl.ConvertCategoryToCategoryView(item);
                results.Add(resutl);
            }
            return results;
        }
    }
}
