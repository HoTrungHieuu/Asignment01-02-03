using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.AddModel
{
    public class CategoryAdd
    {
        [Required]
        public string? CategoryName { get; set; }
        [Required]
        public string? CategoryDesciption { get; set; }
        public short? ParentCategoryId { get; set; }
    }
}
