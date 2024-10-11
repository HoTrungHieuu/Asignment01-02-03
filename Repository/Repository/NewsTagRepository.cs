using DataAccessObject.Models;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class NewsTagRepository : GenericRepository<NewsTag>, INewsTagRepository
    {
        public NewsTagRepository()
        {

        }
        public async Task<List<NewsTag>> GetListNewsTagByNewArticleId(string newsArticleId)
        {
            var listNewsTag = (await GetAllAsync()).FindAll(l => l.NewsArticleId == newsArticleId);
            return listNewsTag;
        }
    }
}
