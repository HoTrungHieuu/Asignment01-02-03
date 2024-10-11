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
    public class NewsArticleService : INewArticleService
    {
        public INewsArticleRepository NewsArticleRepository;
        public NewsArticleService()
        {
            this.NewsArticleRepository = new NewsArticleRepository();
        }
        public async Task<ServiceResult> ViewAllNewsArticle()
        {
            try
            {
                var newsArticles = await NewsArticleRepository.ViewAllNewsArticle();
                return new ServiceResult
                {
                    Status = 200,
                    Message = "List NewsArticles",
                    Data = newsArticles
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
        public async Task<ServiceResult> ViewAllNewsArticleSearchPaging(string name, int sizePaging,int indexPaging)
        {
            try
            {
                var newsArticles = await NewsArticleRepository.GetListNewsArticleSearchPaging(name,sizePaging,indexPaging);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "List NewsArticles",
                    Data = newsArticles
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
        public async Task<ServiceResult> ViewNewsArticleDetail(string newsArticleId)
        {
            try
            {
                var newArticle = NewsArticleRepository.GetById(newsArticleId);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "NewsArticles",
                    Data = newArticle
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
        public async Task<ServiceResult> AddNewsArticle(short accountId,NewsArticleAdd key)
        {
            try
            {
                var NewsArticle = await NewsArticleRepository.AddNewsArticle(accountId, key);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Create NewsArticle Success",
                    Data = NewsArticle
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
        public async Task<ServiceResult> UpdateNewsArticle(short accountId, NewsArticleUpdate key)
        {
            try
            {
                var NewsArticle = await NewsArticleRepository.UpdateNewsArticle(accountId, key);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Update NewsArticle Success",
                    Data = NewsArticle
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
        public async Task<ServiceResult> DeteleNewsArticle(int newsArticleId)
        {
            try
            {
                var NewsArticle = NewsArticleRepository.GetById(newsArticleId);
                if (NewsArticle == null)
                {
                    return new ServiceResult
                    {
                        Status = 404,
                        Message = "NewsArticle Not Found",
                    };
                }
                await NewsArticleRepository.RemoveAsync(NewsArticle);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Delete Success",
                    Data = NewsArticle
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
