using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IAccountService
    {
        public Task<ServiceResult> Login(string email, string password);
        public Task<ServiceResult> Register(string email, string password);
        public Task<ServiceResult> CreateAccount(string email, string password, int role);
    }
}
