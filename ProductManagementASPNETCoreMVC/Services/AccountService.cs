using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository iAccountRepository;
        public AccountService(IAccountRepository accountRepository) { iAccountRepository = accountRepository; }
        public AccountMember GetAccountById(string accountID)
        {
            return iAccountRepository.GetAccountById(accountID);
        }
        public AccountMember GetAccountByEmail(string email)
        {
            return iAccountRepository.GetAccountByEmail(email);
        }
    }
}
