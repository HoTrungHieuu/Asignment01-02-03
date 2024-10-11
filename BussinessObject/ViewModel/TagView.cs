using DataAccessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.ViewModel
{
    public class TagView
    {
        public int TagId { get; set; }

        public string? TagName { get; set; }

        public string? Note { get; set; }

        public void ConvertTagToTagView(Tag key)
        {
            TagId = key.TagId;
            TagName = key.TagName;
            Note = key.Note;
        }
    }
}
