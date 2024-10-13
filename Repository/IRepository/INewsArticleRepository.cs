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
    public interface INewsArticleRepository : IGenericRepository<NewsArticle>
    {
        public Task<List<NewsArticleView>> ViewAllNewsArticle();
        public Task<List<NewsArticleView>> GetListNewsArticleSearchPaging(string name, int sizePaging, int indexPaging);
        public Task<NewsArticleView> AddNewsArticle(NewsArticleAdd key);
        public Task<NewsArticleView?> UpdateNewsArticle(NewsArticleUpdate key);
        public Task<List<NewsArticleView>> ViewStatisticNewsArticle(DateTime fromDate, DateTime toDate);
    }
}
