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
    public interface ITagRepository : IGenericRepository<Tag>
    {
        public Task<List<TagView>> ViewAllTag();
        public Task<List<TagView>> GetListTagSearchPaging(string name, int sizePaging, int indexPaging);
        public Task<TagView> AddTag(TagAdd key);
        public Task<TagView?> UpdateTag(TagUpdate key);
        public List<TagView> ConvertListTagToListTagView(List<Tag> listTag);
    }
}
