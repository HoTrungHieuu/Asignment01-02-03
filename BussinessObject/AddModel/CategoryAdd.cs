using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.AddModel
{
    public class CategoryAdd
    {
        public string? CategoryName { get; set; }

        public string? CategoryDesciption { get; set; }

        public short? ParentCategoryId { get; set; }
    }
}
