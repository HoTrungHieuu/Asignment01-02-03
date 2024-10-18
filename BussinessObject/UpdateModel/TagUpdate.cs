using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.UpdateModel
{
    public class TagUpdate
    {
        [Required]
        public int? Id {  get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Note { get; set; }
    }
}
