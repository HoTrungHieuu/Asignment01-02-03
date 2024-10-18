using BussinessObject.AddModel;
using BussinessObject.UpdateModel;
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
        public Task<ServiceResult> ViewAllAccount();
        public Task<ServiceResult> AccountDetail(int accountId);
        public Task<ServiceResult> Login(string email, string password);
        public Task<ServiceResult> Register(string email, string password);
        public Task<ServiceResult> CreateAccount(AccountAdd key);
        public Task<ServiceResult> UpdateAccount(AccountUpdate key);
    }
}
