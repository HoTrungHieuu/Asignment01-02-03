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

namespace Repository.Repository
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository()
        {

        }
        public async Task<List<TagView>> ViewAllTag()
        {
            try
            {
                var listTag = await GetAllAsync();
                return ConvertListTagToListTagView(listTag);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<TagView>> GetListTagSearchPaging(string name, int sizePaging,int indexPaging)
        {
            try
            {
                var listTag = (await GetAllAsync()).FindAll(l=>l.TagName.ToLower().Contains(name.ToLower()));
                listTag = Paging(listTag,sizePaging,indexPaging);
                return ConvertListTagToListTagView(listTag);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<TagView> AddTag(TagAdd key)
        {
            try
            {
                var lastTag = (await GetAllAsync()).Last();
                int newId = 1;
                if(lastTag != null)
                {
                    newId = lastTag.TagId + 1;
                }
                Tag tag = new()
                {
                    TagId = newId,
                    TagName = key.Name,
                    Note = key.Note,
                };
                await CreateAsync(tag);
                TagView result = new();
                result.ConvertTagToTagView(tag);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<TagView?> UpdateTag(TagUpdate key)
        {
            try
            {
                var tag = GetById(key.Id);
                if (tag == null)
                {
                    return null;
                }
                tag.TagName = key.Name;
                tag.Note = key.Note;
                await UpdateAsync(tag);
                TagView result = new();
                result.ConvertTagToTagView(tag);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<TagView> ConvertListTagToListTagView(List<Tag> listTag)
        {
            List<TagView> results = new();
            foreach(var item in listTag)
            {
                TagView resutl = new();
                resutl.ConvertTagToTagView(item);
                results.Add(resutl);
            }
            return results;
        }
    }
}
