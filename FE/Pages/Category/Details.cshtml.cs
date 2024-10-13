using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessObject.Models;
using BussinessObject.AddModel;

namespace FE.Pages.Category
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccessObject.Models.FUNewsManagementFall2024Context _context;

        public DetailsModel(DataAccessObject.Models.FUNewsManagementFall2024Context context)
        {
            _context = context;
        }

        public CategoryAdd Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
          /*  else
            {
                Category = category;
            }*/
            return Page();
        }
    }
}
