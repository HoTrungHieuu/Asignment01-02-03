using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.UpdateModel
{
    public class CategoryUpdate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]

        public string CategoryDesciption { get; set; }
        [Required]
        public short? ParentCategoryId { get; set; }
        [Required]
        public bool? IsActive { get; set; }
    }
}
