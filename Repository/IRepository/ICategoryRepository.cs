using BussinessObject.AddModel;
using BussinessObject.UpdateModel;
using BussinessObject.ViewModel;
using DataAccessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<List<CategoryView>> ViewAllCategory();
        public Task<List<CategoryView>> GetListCategorySearchPaging(string name, int sizePaging, int indexPaging);
        public Task<CategoryView> AddCategory(CategoryAdd key);
        public Task<CategoryView?> UpdateCategory(CategoryUpdate key);
    }
}
