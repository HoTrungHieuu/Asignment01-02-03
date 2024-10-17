using BussinessObject.AddModel;
using DataAccessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.ViewModel
{
    public class NewsArticleView
    {
        [Key]
        public string? NewsArticleId { get; set; }

        public string? NewsTitle { get; set; }

        public string? Headline { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? NewsContent { get; set; }

        public string? NewsSource { get; set; }

        public string? NewsStatus { get; set; }

        public CategoryView? Category { get; set; }

        public List<TagView>? ListTags { get; set; }

        public short? CreatedById { get; set; }

        public short? UpdatedById { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public void ConvertNewsArticleToNewsArticleView(NewsArticle key,CategoryView cateogry,List<TagView> listTag)
        {
            NewsArticleId = key.NewsArticleId;
            NewsTitle = key.NewsTitle;
            Headline = key.Headline;
            CreatedDate = key.CreatedDate;
            NewsContent = key.NewsContent;
            NewsSource = key.NewsSource;
            if ((bool)key.NewsStatus)
            {
                NewsStatus = "IsActive";
            }
            else
            {
                NewsStatus = "NotActive";
            }
            
            CreatedById = key.CreatedById;
            UpdatedById = key.UpdatedById;
            ModifiedDate = key.ModifiedDate;
            Category = cateogry;
            ListTags = listTag;
        }
    }
}
