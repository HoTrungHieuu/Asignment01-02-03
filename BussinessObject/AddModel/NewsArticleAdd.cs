using BussinessObject.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.AddModel
{
    public class NewsArticleAdd
    {
        [Required]
        public short AccountId { get; set; }
        [Required]
        public string? NewsTitle { get; set; }
        [Required]
        public string? Headline { get; set; }
        [Required]
        public string? NewsContent { get; set; }
        [Required]
        public string? NewsSource { get; set; }
        [Required]
        public short? CategoryId { get; set; }
        [Required]
        public List<int>? ListTagId { get; set; }
    }
}
