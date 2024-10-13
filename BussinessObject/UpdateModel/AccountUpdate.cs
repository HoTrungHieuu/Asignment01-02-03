using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.UpdateModel
{
    public class AccountUpdate
    {
        [Required]
        public short Id { get; set; }
        [Required]
        public string? AccountName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
