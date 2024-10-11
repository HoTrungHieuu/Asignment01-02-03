using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.UpdateModel
{
    public class NewsArticleUpdate
    {
        public int Id { get; set; }
        public string? NewsTitle { get; set; }

        public string? Headline { get; set; }

        public string? NewsContent { get; set; }

        public string? NewsSource { get; set; }
        public bool? NewsStatus { get; set; }

        public short? CategoryId { get; set; }

        public List<int>? ListTagId { get; set; }
    }
}
