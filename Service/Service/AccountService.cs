using BussinessObject.AddModel;
using BussinessObject.UpdateModel;
using DataAccessObject.Models;
using Repository.IRepository;
using Repository.Repository;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class AccountService : IAccountService
    {
        public IAccountRepository accountRepository;
        public AccountService()
        {
            accountRepository = new AccountRepository();
        }
        public async Task<ServiceResult> ViewAllAccount()
        {
            try
            {
                var accounts = await accountRepository.GetAllAsync();
                return new ServiceResult
                {
                    Status = 200,
                    Message = "List Acdount",
                    Data = accounts
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Status = 501,
                    Message = ex.ToString(),
                };
            }
        }
        public async Task<ServiceResult> AccountDetail(int accountId)
        {
            try
            {
                var account = accountRepository.GetById((short)accountId);
                if (account == null)
                {
                    return new ServiceResult
                    {
                        Status = 404,
                        Message = "Not Found",
                    };
                }
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Acdount",
                    Data = account
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Status = 501,
                    Message = ex.ToString(),
                };
            }
        }
        public async Task<ServiceResult> Login(string email, string password)
        {
            try
            {
                var account = await accountRepository.Login(email,password);
                if (account == null)
                {
                    return new ServiceResult
                    {
                        Status = 401,
                        Message = "Login Fail",
                    };
                }
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Login Success",
                    Data = account
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Status = 501,
                    Message = ex.ToString(),
                };
            }
        }
        public async Task<ServiceResult> Register(string email, string password)
        {
            try
            {
                var account = await accountRepository.CreateAccount(email, password, 2);
                if (account == null)
                {
                    return new ServiceResult
                    {
                        Status = 401,
                        Message = "Register Fail",
                    };
                }
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Register Success",
                    Data = account
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Status = 501,
                    Message = ex.ToString(),
                };
            }
        }
        public async Task<ServiceResult> CreateAccount(AccountAdd key)
        {
            try
            {
                var account = await accountRepository.CreateAccount(key.Email,key.Password,key.Role);
                if (account == null)
                {
                    return new ServiceResult
                    {
                        Status = 401,
                        Message = "Create Fail",
                    };
                }
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Create Success",
                    Data = account
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Status = 501,
                    Message = ex.ToString(),
                };
            }
        }
        public async Task<ServiceResult> UpdateAccount(AccountUpdate key)
        {
            try
            {
                var account = await accountRepository.UpdateAccount(key);
                if (account == null)
                {
                    return new ServiceResult
                    {
                        Status = 404,
                        Message = "Account Not Found",
                    };
                }
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Update Success",
                    Data = account
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Status = 501,
                    Message = ex.ToString(),
                };
            }
        }
        public async Task<ServiceResult> DeleteAccount(int accountId)
        {
            try
            {
                var account = accountRepository.GetById((short)accountId);
                if (account == null)
                {
                    return new ServiceResult
                    {
                        Status = 404,
                        Message = "Account Not Found",
                    };
                }
                await accountRepository.RemoveAsync(account);
                return new ServiceResult
                {
                    Status = 200,
                    Message = "Delete Success",
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Status = 501,
                    Message = ex.ToString(),
                };
            }
        }
    }
}
