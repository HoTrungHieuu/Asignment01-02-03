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
    public class NewsArticleRepository : GenericRepository<NewsArticle>, INewsArticleRepository
    {
        ITagRepository tagRepo;
        INewsTagRepository newsTagRepo;
        ICategoryRepository cateRepo;
        public NewsArticleRepository()
        {
            tagRepo = new TagRepository();
            newsTagRepo = new NewsTagRepository();
            cateRepo = new CategoryRepository();
        }
        public async Task<List<NewsArticleView>> ViewAllNewsArticle()
        {
            try
            {
                var listNewsArticle = await GetAllAsync();
                return (await ConvertListNewsArticleToListNewsArticleView(listNewsArticle));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<NewsArticleView>> GetListNewsArticleSearchPaging(string name, int sizePaging, int indexPaging)
        {
            try
            {
                List<NewsArticle> listNewsArticle = new();
                if (name == null)
                {
                    listNewsArticle = await GetAllAsync();
                }
                else
                {
                    listNewsArticle = (await GetAllAsync()).FindAll(l => l.NewsTitle.ToLower().Contains(name.ToLower()));
                }
                listNewsArticle = Paging(listNewsArticle, sizePaging, indexPaging);
                return (await ConvertListNewsArticleToListNewsArticleView(listNewsArticle));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<NewsArticleView> NewsArticleDetail(string newsArticleId)
        {
            try
            {
                var newsArticle = GetById(newsArticleId);
                NewsArticleView result = new();
                result = (await ConvertNewsArticleToNewsArticleView(newsArticle));
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<NewsArticleView> AddNewsArticle(NewsArticleAdd key)
        {
            try
            {
                if (key.ListTagId == null) key.ListTagId = new();
                var lastNewsArticle = (await GetAllAsync()).Last();
                string newId = "1";
                if (lastNewsArticle != null)
                {
                    newId = (int.Parse(lastNewsArticle.NewsArticleId) + 1).ToString();
                }
                NewsArticle newsArticle = new()
                {
                    NewsArticleId = newId,
                    NewsTitle = key.NewsTitle,
                    Headline = key.Headline,
                    CreatedDate = DateTime.Now,
                    NewsContent = key.NewsContent,
                    NewsSource = key.NewsSource,
                    CategoryId = key?.CategoryId,
                    NewsStatus = true,
                    CreatedById = key.AccountId,
                };
                await CreateAsync(newsArticle);
                foreach(var item in key?.ListTagId)
                {
                    await newsTagRepo.CreateAsync(new()
                    {
                        NewsArticleId = newsArticle.NewsArticleId,
                        TagId = item
                    });
                }
                NewsArticleView result = new();
                result = await ConvertNewsArticleToNewsArticleView(newsArticle);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<NewsArticleView?> UpdateNewsArticle(NewsArticleUpdate key)
        {
            try
            {
                var newsArticle = GetById(key.Id);
                if (newsArticle == null)
                {
                    return null;
                }
                newsArticle.NewsTitle = key.NewsTitle;
                newsArticle.Headline = key.Headline;
                newsArticle.NewsContent = key.NewsContent;
                newsArticle.NewsSource = key.NewsSource;
                newsArticle.CategoryId = key.CategoryId;
                newsArticle.NewsStatus = key.NewsStatus;
                newsArticle.UpdatedById = key.AccountId;
                newsArticle.ModifiedDate = DateTime.Now;
                await UpdateAsync(newsArticle);
                var listNewsTag = (await newsTagRepo.GetAllAsync()).FindAll(l=>l.NewsArticleId == newsArticle.NewsArticleId);
                foreach(var item in listNewsTag)
                {
                    await newsTagRepo.RemoveAsync(item);
                }
                foreach (var item in key.ListTagId)
                {
                    await newsTagRepo.CreateAsync(new()
                    {
                        NewsArticleId = newsArticle.NewsArticleId,
                        TagId = item
                    });
                }
                NewsArticleView result = new();
                result = await ConvertNewsArticleToNewsArticleView(newsArticle);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<NewsArticleView>> ViewStatisticNewsArticle(DateTime fromDate, DateTime toDate)
        {
            var listNewsArticle = await GetAllAsync();
            listNewsArticle = listNewsArticle.FindAll(l => l.CreatedDate >= fromDate && l.CreatedDate <= toDate);
            listNewsArticle.OrderBy(l => l.CreatedDate);
            List<NewsArticleView> results = new List<NewsArticleView>();
            results = await ConvertListNewsArticleToListNewsArticleView(listNewsArticle);
            return results;
        }

        private async Task<List<NewsArticleView>> ConvertListNewsArticleToListNewsArticleView(List<NewsArticle> listNewsArticle)
        {
            List<NewsArticleView> results = new();
            foreach (var item in listNewsArticle)
            {
                results.Add(await ConvertNewsArticleToNewsArticleView(item));
            }
            return results;
        }
        private async Task<NewsArticleView> ConvertNewsArticleToNewsArticleView(NewsArticle newsArticle)
        {
            var listNewsTag = await newsTagRepo.GetListNewsTagByNewArticleId(newsArticle.NewsArticleId);
            List<Tag> listTag = new();
            foreach(var item in listNewsTag)
            {
                listTag.Add(tagRepo.GetById(item.TagId));
            }
            List<TagView> listTagView = tagRepo.ConvertListTagToListTagView(listTag);
            CategoryView categoryView = new CategoryView();
            if(newsArticle.CategoryId != null)
            {
                categoryView.ConvertCategoryToCategoryView(cateRepo.GetById(newsArticle.CategoryId));
            }
            else
            {
                categoryView = null;
            }
            NewsArticleView result = new();
            result.ConvertNewsArticleToNewsArticleView(newsArticle,categoryView,listTagView);
            return result;
        }
    }
}
