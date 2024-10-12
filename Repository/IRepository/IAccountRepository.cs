using DataAccessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IAccountRepository : IGenericRepository<SystemAccount>
    {
        public Task<SystemAccount?> Login(string email, string password);
        public Task<SystemAccount> CreateAccount(string email, string password, int role);
    }
}
