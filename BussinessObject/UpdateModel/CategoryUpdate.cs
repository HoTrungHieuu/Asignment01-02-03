﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.UpdateModel
{
    public class CategoryUpdate
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string CategoryDesciption { get; set; }

        public short? ParentCategoryId { get; set; }
        public bool? IsActive { get; set; }
    }
}
