using DataAccessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.ViewModel
{
    public class CategoryView
    {
        public short CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDesciption { get; set; }

        public short? ParentCategoryId { get; set; }

        public bool? IsActive { get; set; }
        public void ConvertCategoryToCategoryView(Category category)
        {
            CategoryId = category.CategoryId;
            CategoryName = category.CategoryName;
            CategoryDesciption = category.CategoryDesciption;
            ParentCategoryId = category.ParentCategoryId;
            IsActive = category.IsActive;
        }
    }
}
