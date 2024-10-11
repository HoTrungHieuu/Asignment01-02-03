using DataAccessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface INewsTagRepository : IGenericRepository<NewsTag>
    {
        public Task<List<NewsTag>> GetListNewsTagByNewArticleId(string newsArticleId);
    }
}
