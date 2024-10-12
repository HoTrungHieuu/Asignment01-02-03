using DataAccessObject.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Extra
{
    public class AdminAccount
    {
        private readonly IConfiguration _configuration;
        public AdminAccount()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }
        public SystemAccount? GetAdminAccount(string email, string password)
        {
            if (email != _configuration["AdminAccount:Email"]) return null;
            if (password != _configuration["AdminAccount:Password"]) return null;
            return new SystemAccount
            {
                AccountEmail = email,
                AccountPassword = password,
                AccountRole = 3
            };
        }
    }
}
