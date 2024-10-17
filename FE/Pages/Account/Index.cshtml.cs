using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessObject.Models;

namespace FE.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly DataAccessObject.Models.FUNewsManagementFall2024Context _context;

        public IndexModel(DataAccessObject.Models.FUNewsManagementFall2024Context context)
        {
            _context = context;
        }

        public IList<SystemAccount> SystemAccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SystemAccount = await _context.SystemAccounts.ToListAsync();
        }
    }
}
