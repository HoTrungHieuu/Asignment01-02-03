using BussinessObject.ViewModel;
using DataAccessObject.Extra;
using DataAccessObject.Models;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AccountRepository : GenericRepository<SystemAccount>, IAccountRepository
    {
        AdminAccount adminAccount;
        public AccountRepository()
        {
            adminAccount = new AdminAccount();
        }
        public async Task<SystemAccount?> Login(string email, string password)
        {
            try
            {
                var account = adminAccount.GetAdminAccount(email, password);
                if(account != null) return account;
                account = (await GetAllAsync()).SingleOrDefault(l => l.AccountEmail == email && l.AccountPassword == password);
                return account;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<SystemAccount> CreateAccount(string email, string password, int role)
        {
            try
            {
                var account = (await GetAllAsync()).SingleOrDefault(l => l.AccountEmail == email);
                if (account != null) return null;
                var lastAccount = (await GetAllAsync()).Last();
                short newId = 1;
                if (lastAccount != null)
                {
                    newId = Convert.ToInt16(lastAccount.AccountId + 1);
                }
                account = new()
                {
                    AccountId = newId,
                    AccountEmail = email,
                    AccountPassword = password,
                    AccountRole = role
                };
                return account;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
